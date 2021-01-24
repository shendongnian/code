    page_load()
    {
      if(!IsPostBack)
      {
                DataTable dt = (DataTable)Session("ExcelData");
                Response.ClearContent();
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
                Response.Charset = "windows-1254"; 
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/xsl";
                string tab = "";
                foreach (DataColumn c in dt.Columns)
                {
                    Response.Write(tab + c.ColumnName);
                    tab = "\t";
                }
    
                \\..somethings about writing to file ...
    
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true; 
                HttpContext.Current.ApplicationInstance.CompleteRequest();
      }
    
    }
