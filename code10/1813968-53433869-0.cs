    [HttpPost]
        public async Task<string> Post([FromForm]string id)
        {          
            String filterType = "id";             
            string filterValues = id;
            string result = string.Empty;            
    
            int batchSize = 50;//max 300, default 300
            String[] fields = { "email", "country", "city", "address", "postalCode", "phone", "company", "billingCountry", "billingCity", "billingPostalCode", "billingStreet", "mainPhone", "website" };//array of field names to retrieve
            String nextPageToken = "";//paging token
    
            Task<string> tr = await getDataLead(filterType, filterValues, batchSize, fields, nextPageToken).ContinueWith((t1) =>
                {
    
                    if (t1.Exception == null)
                    {
                        getLeadsByFilterTypeRootObject data = JsonConvert.DeserializeObject<getLeadsByFilterTypeRootObject>(t1.Result);
                        if (data.success == true)
                        {
                            if (data.result.Count < 2)
                            {
                                result = matchLogic(data.result[0]);                            
                            }
                            else
                            {
                                result = Task.FromResult("not good");
                            }
                        }
                        else
                        {
    
                            result = Task.FromResult("not good");
                        }
                    }
                    else
                    {
                        result = Task.FromResult("not good");
                    }  
                });         
    
              return result;
    
        }
