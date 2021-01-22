    public void ProcessRequest (HttpContext context) 
    {
        HttpFileCollection hfc = context.Request.Files;
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {   
                string imageLocation = "C:\\ImageLocation\\" + theFileNameToSaveAs;
                
                hpf.SaveAs(imageLocation);
            }
        }
        context.Response.Redirect("../callingpage.aspx"); 
    }
