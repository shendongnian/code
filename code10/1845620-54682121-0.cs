    public IHttpActionResult Get(string key) { 
        //...
        DataSet ds = new DataSet(); 
        SqlDataAdapter da = new SqlDataAdapter(cmd2); 
        da.Fill(ds); 
        var json = ds.Tables[0].Rows[0][0].ToString();         
        var response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(json, Encoding.UTF8, "application/json");
        return ResponseMessage(response);
    }
