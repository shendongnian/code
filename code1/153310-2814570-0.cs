        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            // The following line was ImageFormat.Jpeg, but it caused sizing issues
            // in Crystal Reports.  Changing to ImageFormat.Bmp made the squashed
            // problems go away.
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }
