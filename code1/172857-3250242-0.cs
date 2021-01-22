    public void ProcessRequest(HttpContext context)
    {
       StringBuilder myCsv = new StringBuilder();
       foreach(myRow r in myRows) {
         myCsv.AppendFormat("\"{0}\",{1}", r.MyCol1, r.MyCol2);
       }
    
       context.Response.ContentType = "application/csv";
       context.Response.AddHeader("content-disposition", "attachment; filename=myfile.csv");
       context.Response.Write(myCsv.ToString());
    }
