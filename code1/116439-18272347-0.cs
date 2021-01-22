    private static void CombineAndConvertTif(FileInfo inputFile, FileInfo outputFile)
        {
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            Console.Write("Converting {0} to {1}... ", inputFile.Name, outputFile.Name);
            Stopwatch sw = Stopwatch.StartNew();
            using (
                FileStream fs = new FileStream(
                    outputFile.FullName, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                Document document = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                writer.CompressionLevel = 100;
                writer.SetFullCompression();
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                using (Bitmap bm = new Bitmap(inputFile.FullName))
                {
                    int pages = bm.GetFrameCount(FrameDimension.Page);
                    for (int currentPage = 0; currentPage < pages; ++currentPage)
                    {
                        bm.SelectActiveFrame(FrameDimension.Page, currentPage);
                        bm.SetResolution(96, 96);
                        
                        Image img;
                        if (QualityMode == QualityMode.Slow)
                        {
                            #region Low speed, smaller files
                            img = iTextSharp.text.Image.GetInstance(bm, null, true);
                            #endregion
                        }
                        else
                        {
                            #region Fast speed, bigger files
                            using (MemoryStream mem = new MemoryStream())
                            {
                                bm.Save(mem, jgpEncoder, myEncoderParameters);
                                img = Image.GetInstance(mem.ToArray());
                            }
                            #endregion
                        }
                        img.ScalePercent(72f / 200f * 100);
                        img.SetAbsolutePosition(0, 0);
                        cb.AddImage(img);
                        document.NewPage();
                    }
                }
                document.Close();
                writer.Close();
            }
            sw.Stop();
            Console.WriteLine(" time: {0}", sw.Elapsed);
        }
