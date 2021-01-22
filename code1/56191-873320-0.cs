    //add this
    Reponse.Clear(); 
    //from other answer
    Response.ContentType = "text/plain";
    Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.sql", filename));
    Response.Write(yourSQL);
    Response.End;
