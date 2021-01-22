    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] imageBytes = new byte[19201];
                //(Fill it with the data from the unit before doing the rest).
                Bitmap bmp_workarea = new Bitmap(320, 240, System.Drawing.Imaging.PixelFormat.Format4bppIndexed);
                Image newImage = Image.FromStream(new MemoryStream(imageBytes));
                using (Graphics gr = Graphics.FromImage(bmp_workarea))
                {
                    gr.DrawImage(newImage, new Rectangle(0, 0, bmp_workarea.Width, bmp_workarea.Height));
                }
                //now you can use newImage, for example picturebox1.image=newimage
                
            }
        }
    }
