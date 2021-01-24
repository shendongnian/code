    // I don't have a full grasp of your complete eco-system so based on the
    // minimal information provided, this would at least get you close
    public interface IAzureAPI
    {
      public Task<string> GetOrgAsync(string org, string oauth);
    }
    public class AzureAPI : IDisposable
    {
      public async Task<string> GetOrgAsync(string org, string oauth)
      {
        // use *using* not try/catch/finally/dispose
        using (var client = new HttpClient())
        {
          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", oauth);
          var url = "https://dev.azure.com/" + org+ "/_apis/projects?api-version=4.1";
          var response = await client.GetAsync(url);
          // never use `.Result` unless you absolutely know what you are doing
          // always using async/wait if possible
          var result = await response.Content.ReadAsStringAsync(); 
          return result;
       }
      }
    }
