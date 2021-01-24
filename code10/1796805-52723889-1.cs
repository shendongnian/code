        var context_= System.Web.HttpContext.Current;
        string sFileName = context_.Request["sFileName"];
        if (File.Exists(context_.Server.MapPath("~/images/" + sFileName)))
        {
            File.Delete(context_.Server.MapPath("~/images/" + sFileName));
            context_.Response.ContentType = "text/plain";
            context_.Response.Write("Image deleted Successfully!");
        }
        else
        {
            context_.Response.ContentType = "text/plain";
            context_.Response.Write("Image Failed to Delete!");
        }
    }
