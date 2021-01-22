    using (Graphics gr = Graphics.FromImage(SourceImage)) // SourceImage is a Bitmap object
            {                
                var gray_matrix = new float[][] { 
                    new float[] { 0.299f, 0.299f, 0.299f, 0, 0 }, 
                    new float[] { 0.587f, 0.587f, 0.587f, 0, 0 }, 
                    new float[] { 0.114f, 0.114f, 0.114f, 0, 0 }, 
                    new float[] { 0,      0,      0,      1, 0 }, 
                    new float[] { 0,      0,      0,      0, 1 } 
                };
                
                var ia = new System.Drawing.Imaging.ImageAttributes();
                ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                ia.SetThreshold(0.8); // Change this threshold as needed
                var rc = new Rectangle(0, 0, SourceImage.Width, SourceImage.Height);
                gr.DrawImage(SourceImage, rc, 0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel, ia);                
            }
