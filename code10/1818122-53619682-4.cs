    //Your DataSet filled with stored procedure result.
    DataSet ds = dblayer.GetGAROList();
    //Populate DataTable from above DataSet
    DataTable dt = ds.Tables[0];
    //Project your data from DataTable to Dictionary
    var result = (from row in dt.AsEnumerable()
                  group row by row.Field<string>("GARO_Name") into grp
                  select new
                  {
                      GARO_Name = grp.Key,
                      ED_Name = grp.Select(x => x.Field<string>("ED_Name")).ToList()
                  }).ToDictionary(x => x.GARO_Name, x => x.ED_Name);
    //Use above Converter 
    string json = JsonConvert.SerializeObject(result, new CustomJsonConverter());
    //Print formatted json to console
    Console.WriteLine(JObject.Parse(json));
