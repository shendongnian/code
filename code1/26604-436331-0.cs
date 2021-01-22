                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileNameToUse + "\"");
                 Response.CacheControl = "Public";
 
                Response.Write(output);
                Response.Flush();
                Response.Close();
