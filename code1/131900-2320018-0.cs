       private Image getImageFromBytes(byte[] myByteArray)
        {                        
            System.IO.MemoryStream newImageStream = new System.IO.MemoryStream(myByteArray, 0, myByteArray.Length);
            Image image = Image.FromStream(newImageStream, true);
            Bitmap resized = new Bitmap(image, image.Width / 2, image.Height / 2);
            image.Dispose();
            newImageStream.Dispose();
            return resized;
        }
