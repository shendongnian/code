    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.ClearHeaders();
    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);     
    HttpContext.Current.Response.Charset = System.Text.Encoding.Unicode.EncodingName;     
    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode;
    HttpContext.Current.Response.AddHeader("Content-Type", "application/ms-excel");
    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", outputFileName));
    HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
    ...
    table.RenderControl(htw);       
    HttpContext.Current.Response.Write(sw.ToString());
    HttpContext.Current.Response.Flush();
    HttpContext.Current.Response.End();
