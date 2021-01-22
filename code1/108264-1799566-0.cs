    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    #region ExtractImagesFromPDF
            public static void ExtractImagesFromPDF(string sourcePdf, string outputPath)
            {
                // NOTE:  This will only get the first image it finds per page.
                PdfReader pdf = new PdfReader(sourcePdf);
                RandomAccessFileOrArray raf = new iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdf);
    
                try
                {
                    for (int pageNumber = 1; pageNumber <= pdf.NumberOfPages; pageNumber++)
                    {
                        PdfDictionary pg = pdf.GetPageN(pageNumber);
                        PdfDictionary res =
                          (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
                        PdfDictionary xobj =
                          (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
                        if (xobj != null)
                        {
                            foreach (PdfName name in xobj.Keys)
                            {
                                PdfObject obj = xobj.Get(name);
                                if (obj.IsIndirect())
                                {
                                    PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                                    PdfName type =
                                      (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));
                                    if (PdfName.IMAGE.Equals(type))
                                    {
    
                                        int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                                        PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                                        PdfStream pdfStrem = (PdfStream)pdfObj;
                                        byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                                        if ((bytes != null))
                                        {
                                            using (System.IO.MemoryStream memStream = new System.IO.MemoryStream(bytes))
                                            {
                                                memStream.Position = 0;
                                                System.Drawing.Image img = System.Drawing.Image.FromStream(memStream);
                                                // must save the file while stream is open.
                                                if (!Directory.Exists(outputPath))
                                                    Directory.CreateDirectory(outputPath);
    
                                                string path = Path.Combine(outputPath, String.Format(@"{0}.jpg", pageNumber));
                                                System.Drawing.Imaging.EncoderParameters parms = new System.Drawing.Imaging.EncoderParameters(1);
                                                parms.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 0);
    // GetImageEncoder is found below this method
                                                System.Drawing.Imaging.ImageCodecInfo jpegEncoder = GetImageEncoder("JPEG");
                                                img.Save(path, jpegEncoder, parms);
                                                break;
    
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
    
                catch
                {
                    throw;
                }
                finally
                {
                    pdf.Close();
                }
    
    
            }
            #endregion
    
           #region GetImageEncoder
            public static System.Drawing.Imaging.ImageCodecInfo GetImageEncoder(string imageType)
            {
                imageType = imageType.ToUpperInvariant();
    
    
    
                foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
                {
                    if (info.FormatDescription == imageType)
                    {
                        return info;
                    }
                }
    
                return null;
            }
            #endregion
