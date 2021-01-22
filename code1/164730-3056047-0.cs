    using System.IO;
    using System.Drawing;
    ...
    String filePath = Server.MapPath("").ToString() + "\images\img1.jpg";
    if(File.Exists(filePath))
    {
        Image imgg1 = Image.FromFile(filePath);
    }
    else
    {
        lblError.Text = "Please upload a picture for this student";
        lblError.Visible = true;
    }
