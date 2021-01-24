    using (MemoryStream ms2 = new MemoryStream())
        {
            croppedBitmap.Save(ms2, ImageFormat.Jpeg);
            byte[] byteImage = ms2.ToArray();
            var croppedBase64 = Convert.ToBase64String(byteImage);
            return croppedBase64;
        }
