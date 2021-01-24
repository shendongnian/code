    //Make a global variable for your method to access
      List<liveScoreData> globalLiveScore = new List<liveScoreData>();
    
          public void liveScore() 
            {
                var result = new List<liveScoreData>();
                try
                {
        
                    Guid guidSifre = Guid.NewGuid();
                    string guid = guidSifre.ToString();
                    string result = CreateMD5forChecksum(guid);
        
        
        
                    using (var client = new WebClient())
                    {
                        var values = new NameValueCollection();
                        values["result"] = result;
                        values["guid"] = guid;
        
        
        
                        var response = client.UploadValues("http://abcd.com/admin/LiveScore", values);
        
                        var responseString = Encoding.Default.GetString(response);
        
        
        
                        var responseResult = JsonConvert.DeserializeObject(responseString);
                        result = JsonConvert.DeserializeObject<List<liveScoreData>>(responseResult.ToString());
        
        
        
                        Mehmet.liveScoreDataList = result;
        
        
                    }
                }
                catch (Exception ex)
                {
                    var exc = ex;
                }
        
        
                globalLiveScore = result;
        
        
        
            }
