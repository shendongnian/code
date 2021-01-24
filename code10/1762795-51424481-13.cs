    public HttpResponseMessage Download()
    {
    	var results = (from violations in _db.tblMappViolations
    	   where violations.MemberID == memberId
    	   select new IncomingViolations
    		   {
    			   Contact = violations.ContactName,
    			   Address = violations.str_Address,
    			   City = violations.str_City,
    			   State = violations.str_State,
    			   Zip = violations.str_Zipcode,
    			   Country = violations.str_Country,
    			   Phone = violations.str_Phone,
    			   Email = violations.str_Email,
    			   Website = violations.str_WebSite,
    		   });
    
    	MemoryStream stream = new MemoryStream();
    	StreamWriter writer = new StreamWriter(stream);
    	foreach(var result in results)
    	{
    		sb.Append(results.Contact+",");
    		sb.Append(results.Address+",");
    		sb.Append(results.City+",");
    		sb.Append(results.State+",");
    		sb.Append(results.Zip+",");
    		sb.Append(results.Country+",");
    		sb.Append(results.Phone+",");
    		sb.Append(results.Email+",");
    		sb.Append(results.Website+",");
    		sb.Append(Enviroment.NewLine);
    	}
    	writer.Write(sb.ToString());
    	writer.Flush();
    	stream.Position = 0;
    
    	HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    	result.Content = new StreamContent(stream);
    	result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
    	result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Export.csv" };
    
    	return result;
    }
