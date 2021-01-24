      List<SharepointDTO.RootObject> results = new List<SharepointDTO.RootObject>();
    	
      for (int i = 0; i < 10000; i = i + 5000)
                {
                    SP_StrainCodes = "GetByTitle('S%20Codes')/items?$skiptoken=Paged=TRUE%26p_ID=" + i + "&$top=1";
                    core_URL = BaseURL_SP + SP_StrainCodes;
    
                    using (var client_sharePoint = new HttpClient(handler))
                    {
                        var response = client_sharePoint.GetAsync(core_URL).Result;
                        var responsedata = await response.Content.ReadAsStringAsync();
                        returnObj = JsonConvert.DeserializeObject<SharepointDTO.RootObject>(responsedata);
    
                        if (returnObj.d.Next == null)
                            continue;
                   }
    			   
    			   results.Add(returnObj);
                }
                return results;
