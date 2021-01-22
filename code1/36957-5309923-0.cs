    using System.Drawing;
    using System.Web;
    
    private Image GetImageFile(HttpPostedFileBase postedFile)
    {
       if (postedFile == null) return null;
       return Image.FromStream(postedFile.InputStream);
    }
