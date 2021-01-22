    // PageLoad event of your getpdf.aspx page :
    long pdfId= Convert.ToInt64(Request.QueryString["pdfid"]);
    
    using (var conn = new SqlConnection(connectionString))
    {
    	using (var command = new SqlCommand(
    		"SELECT PDFFile FROM PDFTable WHERE PDFId = @PDFID", conn))
    	{
    		command.Parameters.Add("@PDFID", SqlDbType.Int).Value = pdfId;
    		conn.Open();
    	
    		Response.ContentType = "application/pdf";
    		Response.BinaryWrite((byte[]) command.ExecuteScalar());
    	}
    }
