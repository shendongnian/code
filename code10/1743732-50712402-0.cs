    public async void DatabaseCreate()
                {
                    if (!await DatabaseExist())
                    {
                        var contents = new StringContent("", Encoding.UTF8, "text/plain");
                        var byteArray = Encoding.ASCII.GetBytes("user:pass");
                        client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(byteArray));
                        this.uri = "http://localhost:5984/databasename";
                        var response = await client.PutAsync(this.uri, contents);
                        Console.WriteLine(response.Content.ReadAsStringAsync().Result); 
                    }
                }
