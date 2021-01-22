    using(MemoryStream ms = new MemoryStream(4096))
    {
       myChart.SaveImage(ms,ImageFormat.Png);
       using(Bitmap img = Image.FromStream(ms))
       {
         using(Graphics g = Graphics.FromImage(img))
           g.DrawImage( b, 0, 0, newWidth, newHeight );
         }
         img.Save("where\to\save\chart.png",ImageFormat.Png);
       }
    }
   
