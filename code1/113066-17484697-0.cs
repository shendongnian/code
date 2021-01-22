     private void button4_Click(object sender, EventArgs e)
      {
                String[] files;
                int count = 0;
                files = System.IO.Directory.GetFiles(@"C:/dataset");
                foreach (string file in files)
                {
                Bitmap tempBmp = new Bitmap(file);
                Bitmap bmp = new Bitmap(tempBmp, 200, 200);
    
                bmp.Save(
                @"C:/Newdataset1/" + count + ".jpg",
                System.Drawing.Imaging.ImageFormat.Jpeg);
                count++;
                }  
  }
