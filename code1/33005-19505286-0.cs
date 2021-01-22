    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Drawing;
    using System.Drawing.Text;
     
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fontName = "YourFont.ttf";
            PrivateFontCollection pfcoll = new PrivateFontCollection();
            //put a font file under a Fonts directory within your application root
            pfcoll.AddFontFile(Server.MapPath("~/Fonts/" + fontName));
            FontFamily ff = pfcoll.Families[0];
            string firstText = "Hello";
            string secondText = "Friend!";
     
            PointF firstLocation = new PointF(10f, 10f);
            PointF secondLocation = new PointF(10f, 50f);
            //put an image file under a Images directory within your application root
            string imageFilePath = Server.MapPath("~/Images/YourImage.jpg");
            Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(imageFilePath);//load the image file
     
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font f = new Font(ff, 14, FontStyle.Bold))
                {
                    graphics.DrawString(firstText, f, Brushes.Blue, firstLocation);
                    graphics.DrawString(secondText, f, Brushes.Red, secondLocation);
                }
            }
            //save the new image file within Images directory
            bitmap.Save(Server.MapPath("~/Images/" + System.Guid.NewGuid() + ".jpg"));
            Response.Write("A new image has been created!");
        } 
    }
