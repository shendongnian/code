    public int ExtractPages(string sourcePdfPath, string DestinationFolder)
            {
                int p = 0;
                try
                {
                    iTextSharp.text.Document document;
                    iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(new iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdfPath), new ASCIIEncoding().GetBytes(""));
                    if (!Directory.Exists(sourcePdfPath.ToLower().Replace(".pdf", "")))
                    {
                        Directory.CreateDirectory(sourcePdfPath.ToLower().Replace(".pdf", ""));
                    }
                    else
                    {
                        Directory.Delete(sourcePdfPath.ToLower().Replace(".pdf", ""), true);
                        Directory.CreateDirectory(sourcePdfPath.ToLower().Replace(".pdf", ""));
                    }
    
                    for (p = 1; p <= reader.NumberOfPages; p++)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            document = new iTextSharp.text.Document();
                            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream);
                            writer.SetPdfVersion(iTextSharp.text.pdf.PdfWriter.PDF_VERSION_1_2);
                            writer.CompressionLevel = iTextSharp.text.pdf.PdfStream.BEST_COMPRESSION;
                            writer.SetFullCompression();
                            document.SetPageSize(reader.GetPageSize(p));
                            document.NewPage();
                            document.Open();
                            document.AddDocListener(writer);
                            iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                            iTextSharp.text.pdf.PdfImportedPage pageImport = writer.GetImportedPage(reader, p);
                            int rot = reader.GetPageRotation(p);
                            if (rot == 90 || rot == 270)
                            {
                                cb.AddTemplate(pageImport, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(p).Height);
                            }
                            else
                            {
                                cb.AddTemplate(pageImport, 1.0F, 0, 0, 1.0F, 0, 0);
                            }
                            document.Close();
                            document.Dispose();
                            File.WriteAllBytes(DestinationFolder + "/" + p + ".pdf", memoryStream.ToArray());
                        }
                    }
                    reader.Close();
                    reader.Dispose();
                }
                catch
                {
                }
                finally
                {
                    GC.Collect();
                }
                return p - 1;
               
            }
