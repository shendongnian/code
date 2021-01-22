            private void LoadImage()
            {
                string src = string.empty;
                byte[] mergedImageData = new byte[0];
    
                mergedImageData = MergeTwoImageByteArrays(watermarkByteArray, backgroundImageByteArray);
                src = "data:image/png;base64," + Convert.ToBase64String(mergedImageData);
                MyImage.ImageUrl = src;
            }
    
            private byte[] MergeTwoImageByteArrays(byte[] imageBytes, byte[] imageBaseBytes)
            {
                byte[] mergedImageData = new byte[0];
                using (var msBase = new MemoryStream(imageBaseBytes))
                {
                    System.Drawing.Image imgBase = System.Drawing.Image.FromStream(msBase);
                    Graphics gBase = Graphics.FromImage(imgBase);
                    using (var msInfo = new MemoryStream(imageBytes))
                    {
                        System.Drawing.Image imgInfo = System.Drawing.Image.FromStream(msInfo);
                        Graphics gInfo = Graphics.FromImage(imgInfo);
                        gBase.DrawImage(imgInfo, new Point(0, 0));
                        //imgBase.Save(Server.MapPath("_____testImg.png"), ImageFormat.Png);
                        MemoryStream mergedImageStream = new MemoryStream();
                        imgBase.Save(mergedImageStream, ImageFormat.Png);
                        mergedImageData = mergedImageStream.ToArray();
                        mergedImageStream.Close();
                    }
                }
                return mergedImageData;
            }
