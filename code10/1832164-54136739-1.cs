    public static async Task<string> TEXT()
    {
         Uri uri = new Uri("http://myaddress");
         HttpClient hc = new HttpClient();
         hc.DefaultRequestHeaders.Add("SOAPAction", "Some Action");
         var xmlStr = "SoapContent"; //not displayed here for simplicity
         var content = new StringContent(xmlStr, Encoding.UTF8, "text/xml");
    
         var string = null;
         using (HttpResponseMessage response = await hc.PostAsync(uri, content))
         {
             var soapResponse = await response.Content.ReadAsStringAsync();
             value = await response.Content.ReadAsStringAsync();
         }
    
         return value;
     }
