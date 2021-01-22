    Response.Clear(); //eliminates issues where some response has already been sent
    Response.ContentType = "text/plain";
    Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.sql", filename));
    Response.Write(yourSQL);
    Response.End();
