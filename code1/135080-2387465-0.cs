    	  	Response.Clear();
	 		Response.AddHeader("content-disposition", "attachment;filename=report.xls");
	  		Response.Charset = "";
			Response.ContentType = "application/vnd.xls";
			var stringWrite = new System.IO.StringWriter();
	 		var htmlWrite = new HtmlTextWriter(stringWrite);
			this.gridView.RenderControl(htmlWrite);
			Response.Write(stringWrite.ToString());
			Response.End();
