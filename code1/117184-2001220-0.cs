    using System;
    using System.Drawing;
    using System.Windows.Forms;
       
    class ImageReflection: Form
    {
         Image image = Image.FromFile("Color.jpg");
       
         public static void Main()
         {
              Application.Run(new ImageReflection());
         }
         public ImageReflection()
         {
              ResizeRedraw = true;
              
         }
         protected override void OnPaint(PaintEventArgs pea)
         {
              DoPage(pea.Graphics, ForeColor,ClientSize.Width, ClientSize.Height);
         }     
         protected void DoPage(Graphics grfx, Color clr, int cx, int cy)
         {
              int cxImage = image.Width;
              int cyImage = image.Height;
       
              grfx.DrawImage(image, cx / 2, cy / 2,  cxImage,  cyImage);
              grfx.DrawImage(image, cx / 2, cy / 2, -cxImage,  cyImage);
              grfx.DrawImage(image, cx / 2, cy / 2,  cxImage, -cyImage);
              grfx.DrawImage(image, cx / 2, cy / 2, -cxImage, -cyImage);
         }
    }
