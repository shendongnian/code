    Response.Clear(); 
    Response.AddHeader("content-disposition", "attachment;filename=" + Request["f"]);
    Response.Charset = "";
    Response.ContentType = "application/vnd.xls";
    
    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    stringWrite = AppendMyFile();
    
    Response.Write(stringWrite.ToString());
    Response.End();
