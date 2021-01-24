                Graphics g = this.CreateGraphics();
                bmp = new Bitmap(this.Size.Width, this.Size.Height + 10, g);
                Graphics mg = Graphics.FromImage(bmp);
                mg.CopyFromScreen(this.Location.X + 20, this.Location.Y + 25 ,40, 47, this.Size);
                // Save the screenshot to the specified path that the user has chosen.
                bmp.Save("Screenshot.png", ImageFormat.Png);
                Document document = new Document();
                document.SetMargins(1,1,1,1);
                using (var stream = new FileStream("test.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    using (var imageStream = new FileStream("Screenshot.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image = iTextSharp.text.Image.GetInstance(imageStream);                       
                        float maxWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                        float maxHeight = document.PageSize.Height - document.TopMargin - document.BottomMargin;
                        if (image.Height > maxHeight || image.Width > maxWidth)
                            image.ScaleToFit(maxWidth, maxHeight);
                        document.Add(image);
                    }
                    document.Close();
                }
            
