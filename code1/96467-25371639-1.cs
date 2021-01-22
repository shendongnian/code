    using (DataSetTableAdapters.SQSTableAdapter tbl_SQS = new DataSetTableAdapters.SQSTableAdapter())
    {
        try
        {
		    bodyXML = @"<?xml version="1.0" encoding="UTF-8" standalone="yes"?><test></test>";
	    	bodyXMLutf16 = bodyXML.Replace("UTF-8", "UTF-16");
	    	tbl_SQS.Insert(messageID, receiptHandle, md5OfBody, bodyXMLutf16, sourceType);
	    }
	    catch (System.Data.SqlClient.SqlException ex)
	    {
	    	Console.WriteLine(ex.Message);
	    	Console.ReadLine();
	    }
    }
