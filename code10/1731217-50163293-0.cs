     /// <summary>
            /// 
            /// </summary>
            /// <param name="inboundFaxBytes"></param>
            /// <returns></returns>
            public static byte[] ConvertToPDFArray(byte[] inboundFaxBytes)
            {
                byte[] imagePdfBytes = null;
    
                try
                {                          
                   
                    using (MemoryStream ms = new MemoryStream())
                    {
                       
                        iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 50, 50);
                    
                        MemoryStream msBmp = new MemoryStream();
                        msBmp.Write(inboundFaxBytes, 0, inboundFaxBytes.Length);
                        Bitmap faxDocBitmap = new Bitmap(msBmp);
                        
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms);
    
                        int totalPages = faxDocBitmap.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
    
                        //document.SetPageSize(PageSize.A4);
                        document.Open();
    
                        PdfContentByte cb = writer.DirectContent;
                        for (int page = 0; page < totalPages; ++page)
                        {
                            
                            faxDocBitmap.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, page);
                       
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(faxDocBitmap, System.Drawing.Imaging.ImageFormat.Bmp);
    
    
                            img.ScalePercent(72f / img.DpiX * 100, 72f / img.DpiY * 100);
                            img.SetAbsolutePosition(0, 0);
    
                            // Memory Stream is not expandable
                            cb.AddImage(img);
    
                            document.NewPage();
                        
                        }
                        document.Close();
                        imagePdfBytes = ms.ToArray();
                        ms.Dispose();
                       
    
                    }
    
                }
                catch (Exception e)
                {
                    throw e;
                }
                return imagePdfBytes;
            }
