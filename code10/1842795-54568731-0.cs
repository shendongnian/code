    using System.Net.Http;
    using Newtonsoft.Json;
    public async Task PerformPost(MyObject obj)
    {
        try
        {
            HttpClient client=new HttpClient();
            string str = JsonConvert.SerializeObject(obj);
           
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
    
            var response = await this.client.PostAsync("http://[myhost]:[myport]/[mypath]",
                                   content);
          
            string resp = await response.Content.ReadAsStringAsync();
            //deserialize your response using JsonConvert.DeserializeObject<T>(resp)
        }
        catch (Exception ex)
        {
            Console.WriteLine("Threw in client" + ex.Message);
            throw;
        }
    
    }
    public static async Task Main(){
        MyObject myObject=new MyObject{ID=1,Name="name"};
        await PerformPost(myObject);
    
    }
