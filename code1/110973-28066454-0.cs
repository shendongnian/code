    using (System.Drawing.Bitmap newImage = new System.Drawing.Bitmap(newWidth, newHeight,
                    // System.Drawing.Imaging.PixelFormat.Format24bppRgb // OMG bug
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb 
                    ))
                {
