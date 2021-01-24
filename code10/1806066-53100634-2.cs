    using System.Configuration;
    using Newtonsoft.Json;
    
    [System.Web.Services.WebMethod]
    public static string getGenderCount() 
    {
    
     var connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
     var ListOfParticipantGender = new List<ParticipantGender>();
     
     using(var conn = new SqlConnection(connStr))
     {
        conn.Open();
         
        using(var cmd = new SqlCommand("getGenderCount", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;            
            
            using(var rdr = cmd.ExecuteReader())
            {
                if (rdr.HasRows)
                {    
                    while (rdr.Read()) {
                        
                        ListOfParticipantGender.Add(
                                new ParticipantGender 
                                {
                                    cnt = rdr.GetValue(0).ToString(),
                                    gender = rdr.GetValue(1).ToString(),
                        
                                }
                           );
                    }
                }
            }
        }
     }
    
     var json = JsonConvert.SerializeObject(ListOfParticipantGender);
    
     return json;
    }
