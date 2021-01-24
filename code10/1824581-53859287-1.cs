    private static void SaveLabel(string label, string labelDir, string caseNumber)
        {
            var zpl = Encoding.UTF8.GetBytes(label);
            var destFileName = $@"{labelDir}\{caseNumber}.pdf";
            // adjust print density (8dpm), label width (4 inches), label height (6 inches), and label index (0) as necessary
            var request = (HttpWebRequest)WebRequest.Create("http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/");
            request.Method = "POST";
            request.Accept = "application/pdf"; // omit this line to get PNG images back
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = zpl.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(zpl, 0, zpl.Length);
            requestStream.Close();
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();
                if (File.Exists(destFileName))
                {
                    var oldStream = File.OpenRead(destFileName);
                    var oldFileName = $@"{labelDir}\{caseNumber}-1.pdf";
                    using (var fileStream = File.Open(oldFileName, FileMode.Create))
                    {
                        oldStream.CopyTo(fileStream);
                        oldStream.Close();
                        fileStream.Close();
                    }
                    var newFileName = $@"{labelDir}\{caseNumber}-2.pdf";
                    using (var fileStream = File.Open(newFileName, FileMode.Create))
                    {
                        responseStream?.CopyTo(fileStream);
                        responseStream?.Close();
                        fileStream.Close();
                    }
                    File.Delete(destFileName);
                    using (var pdfOne = PdfReader.Open(oldFileName, PdfDocumentOpenMode.Import))
                    {
                        using (var pdfTwo = PdfReader.Open(newFileName, PdfDocumentOpenMode.Import))
                        {
                            using (var outPdf = new PdfDocument())
                            {
                                CopyPages(pdfOne, outPdf);
                                CopyPages(pdfTwo, outPdf);
                                outPdf.Save(destFileName);
                            }
                        }
                    }
                    File.Delete(oldFileName);
                    File.Delete(newFileName);
                }
                else
                {
                    using (var fileStream = File.Open(destFileName, FileMode.Create))
                    {
                        responseStream?.CopyTo(fileStream);
                        responseStream?.Close();
                        fileStream.Close();
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(@"Error: {0}", e.Status);
            }
        }
