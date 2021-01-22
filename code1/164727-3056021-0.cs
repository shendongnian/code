    string path = Server.MapPath("~/images/img1.jpg");
    if (System.IO.File.Exists(path))
    {
        System.Drawing.Image imgg1 = System.Drawing.Image.FromFile(path);
    }
    else
    {
        Response.Write("<script>alert('Please Select and upload Student's Photo');</script>");
    }
