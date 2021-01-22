     public string FileUpload( HttpPostedFileBase file )
      {
         Bitmap bmp = new Bitmap(file.InputStream);
         string valid = "";
         for(int i = 0; i < bmp.Width; i++) {
            for(int j = 0; j < bmp.Height; j++) {
               if(bmp.GetPixel(i , j).B < 20) {
                  if(bmp.GetPixel(i , j).B == bmp.GetPixel(i , j).G &&
                     bmp.GetPixel(i , j).B == bmp.GetPixel(i , j).R) {
                     valid = valid + bmp.GetPixel(i , j). + "<br/>";
                     bmp.SetPixel(i , j , Color.DarkGreen);
                  }
               }
            }
         }
         SaveImage(bmp);
         return valid;
      }
      private void SaveImage( Bitmap newbmp )
      {
         string path = Path.Combine(Server.MapPath("~/Images") , "ScaledImage.jpeg");
         newbmp.Save(path , System.Drawing.Imaging.ImageFormat.Jpeg);
      }
