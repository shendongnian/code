    Use     
      
     Response.Clear();
     Response.ContentType = "application/octet-stream";
     Response.AddHeader("Content-Disposition", "attachment; filename=Report.PDF");                                            
     Response.WriteFile(Server.MapPath("~/YourPath/Report.PDF"));
     Response.End();
