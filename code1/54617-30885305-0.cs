        byte[] bytes = {};
            
        bytes = GetBytesFromDB();  // I use a similar way to get pdf data from my DB
        Response.Clear();
        Response.ClearHeaders();
        Response.Buffer = true;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + anhangTitel);
        Response.AppendHeader("Content-Length", bytes.Length.ToString());
        this.Context.ApplicationInstance.CompleteRequest();
