    public async Task<JiraCookie> GetCookieAsync(string myJsonUserNamePassword, string JiraCookieEndpointUrl)
    {
    	using (var client = new HttpClient())
            {
            	var response = await client.PostAsync(
                    JiraCookieEndpointUrl,
                    new StringContent(myJsonUserNamePassword, Encoding.UTF8, "application/json"));
        		var json = response.Content.ReadAsStringAsync().Result;
                    var jiraCookie= JsonConvert.DeserializeObject<JiraCookie>(json);
                    return jArr;
             }
    }
    
    public class JiraCookie
    {
    	public Session session { get; set; }
    }
        
    public class Session
    {
    	public string name { get; set; }
        public string value { get; set; }
    }
