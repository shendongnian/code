        //OnClick server Handler
        Response.Clear();
        Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", "file_name"));
        Response.ContentType = "application/octet-stream";
        Response.WriteFile("file_path");
        Response.End();
