        [HttpPost]
        public void SaveImage(string base64image)
        {
    
          Bitmap bmp = Base64ToBitmap(base64image);
         //do something with bitmap
      
        }
        public Bitmap Base64ToBitmap(String base64String)
        {
        byte[] imageAsBytes = Base64.Decode(base64String, Base64Flags.Default);
        return BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);
        }
