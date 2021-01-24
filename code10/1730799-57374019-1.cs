        public async Task Tenant_Create_Success(AddTenantRequestdto addTenantRequest)
                {
                    HttpClient Client = new HttpClient();
                   
                    var formDictionary = new Dictionary<string, string>();
                  
                   
                    formDictionary.Add("EnableOTP", JsonConvert.SerializeObject(addTenantRequest.EnableOTP));
                     formDictionary.Add("ApplicationName", JsonConvert.SerializeObject(addTenantRequest.ApplicationName));
                    
                    formDictionary.Add("TenantLogo", JsonConvert.SerializeObject(addTenantRequest.TenantLogo));           
        
                    var formContent = new FormUrlEncodedContent(formDictionary);
                   
                    var response = await Client.PostAsync("http://localhost:61234/Tenants/CreateTenant", formContent);
                    response.StatusCode.Should().Be(HttpStatusCode.OK);
                }
