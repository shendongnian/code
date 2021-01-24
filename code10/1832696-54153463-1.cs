    public static TestResponse PerformStuff()
    {
        var response = new TestResponse();
   
        var idHash = new HashSet<int> (thirdpartylib.Methodforid());
        SqlCommand cmd = DB.GetSqlCommand("proc_name_for_all_ids");
        using (SqlDataReader dr = new SqlDataReader(DB.GetDataReader(cmd)) { 
            while (dr.Read()) {
                var id = dr.GetInt32("id");
                if (idHash.Contains(id)) {
                    testReq = new TestRequest();
                    testReq.col1 = dr.GetInt32("col1");
                    testReq.col2 = dr.GetBoolean("col2");
                    testReq.col3 = dr.GetString("col3");
                    testReq.col4 = dr.GetBoolean("col4");
                    testReq.col5 = dr.GetString("col5");
                    testReq.col6 = dr.GetBoolean("col6");
                    testReq.col7 = dr.GetString("col7");
                    var output = thirdpartylib.MethodforResponse(request);
                    foreach (var data in output.Elements())  {
                        response.col4 = Convert.ToInt32(data.Id().Class());
                        response.col2 = data.Id().Name().ToString();
                    }
                } /* end if hash.Contains(id) */  
            }  /* end while dr.Read() */
        } /* end using() */
        return response;
    }
