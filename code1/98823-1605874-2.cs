    //For MVC ver 2 use:
    [HttpPost]
    //For MVC ver 1 use:
    //[AcceptVerbs(HttpVerbs.Post)] 
    public ActionResult Upload()
    {
        try
        {
            foreach (HttpPostedFile file in Request.Files)
            {
                //Save to a file
                file.SaveAs(Path.Combine("C:\\File_Store\\", Path.GetFileName(file.FileName)));
                
                // * OR *
                //Use file.InputStream to access the uploaded file as a stream
                byte[] buffer = new byte[1024];
                int read = file.InputStream.Read(buffer, 0, buffer.Length);
                while (read > 0)
                {
                    //do stuff with the buffer
                    read = file.InputStream.Read(buffer, 0, buffer.Length);
                }
            }
            return Json(new { Result = "Complete" });
        }
        catch (Exception)
        {
            return Json(new { Result = "Error" });
        }
    }
