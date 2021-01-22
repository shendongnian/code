    public  void SplitPDFByBookMark(string fileName)
        {
            string sInFile = fileName;
            var pdfReader = new PdfReader(sInFile);
            try
            {
                IList<Dictionary<string, object>> bookmarks = SimpleBookmark.GetBookmark(pdfReader);
                for (int i = 0; i < bookmarks.Count; ++i)
                {
                    IDictionary<string, object> BM = (IDictionary<string, object>)bookmarks[i];
                    IDictionary<string, object> nextBM = i == bookmarks.Count - 1 ? null : bookmarks[i + 1];
                    string startPage = BM["Page"].ToString().Split(' ')[0].ToString();
                    string startPageNextBM = nextBM == null ? "" + (pdfReader.NumberOfPages + 1) : nextBM["Page"].ToString().Split(' ')[0].ToString();
                    SplitByBookmark(pdfReader, int.Parse(startPage), int.Parse(startPageNextBM), bookmarks[i].Values.ToArray().GetValue(0).ToString() + ".pdf", fileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SplitByBookmark(PdfReader reader, int pageFrom, int PageTo, string outPutName, string inPutFileName)
        {
            Document document = new Document();
            using (var fs = new FileStream(Path.GetDirectoryName(inPutFileName) + '\\' + outPutName, System.IO.FileMode.Create))
            {
                try
                {
                    using (var writer = PdfWriter.GetInstance(document, fs))
                    {
                        document.Open();
                        PdfContentByte cb = writer.DirectContent;
                        //holds pdf data
                        PdfImportedPage page;
                        if (pageFrom == PageTo && pageFrom == 1)
                        {
                            document.NewPage();
                            page = writer.GetImportedPage(reader, pageFrom);
                            cb.AddTemplate(page, 0, 0);
                            pageFrom++;
                            fs.Flush();
                            document.Close();
                            fs.Close();
                        }
                        else
                        {
                            while (pageFrom < PageTo)
                            {
                                document.NewPage();
                                page = writer.GetImportedPage(reader, pageFrom);
                                cb.AddTemplate(page, 0, 0);
                                pageFrom++;
                                fs.Flush();
                                document.Close();
                                fs.Close();
                            }
                        }
                    }
                    //PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //finally
                //{
                //    if (document.IsOpen())
                //        document.Close();
                //    if (fs != null)
                //        fs.Close();
                //}
            }
            //FileStream fs = new System.IO.FileStream(System.IO.Path.GetDirectoryName(inPutFileName) + '\\' + outPutName, System.IO.FileMode.Create);
        }
