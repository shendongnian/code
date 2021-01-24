    public static async void ApproveRelease()
    {
      try
      {
        var username = "alternate auth or PAT";
        var password = "password";
        string accountName = "https://account.visualstudio.com";
        string projectName = "projectname";
        int approvalid = id;
        var approveReleaseUri = "https://accountname.vsrm.visualstudio.com/projectname/_apis/release/approvals/approvlID?api-version=4.1-preview.3";
    
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(
              System.Text.ASCIIEncoding.ASCII.GetBytes(
                string.Format("{0}:{1}", username, password))));
    
            var method = new HttpMethod("PATCH");
            string approvveReleaseMetaData = "{\"status\":\"approved\", \"comments\":\"Good to go\"}";
            var request = new HttpRequestMessage(method, string.Format(approveReleaseUri, accountName, projectName, approvalid, apiVersion))
            {
                Content = new StringContent(approvveReleaseMetaData, Encoding.UTF8, "application/json")
            };
    
            using (HttpResponseMessage response = client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
        }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
