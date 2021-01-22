     protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = "uploads/";
    
            if (Request.Files.Count <= 0)
            {
                Response.Write("No file uploaded");
            }
            else
            {
                for (int i = 0; i < Request.Files.Count; ++i)
                {
                    HttpPostedFile file = Request.Files[i];
                    file.SaveAs(Server.MapPath(filePath + file.FileName));
                    Response.Write("File uploaded");
                }
            }
    
        }
