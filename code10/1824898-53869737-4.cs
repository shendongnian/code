    using (HttpResponseMessage response = await client.PostAsJsonAsync(
          "https://my_tfs_server/tfs/DefaultCollection/PROJECTNAME/_apis/wit/workitems/$task?api-version=4.1",
          createStoryRequest))
        {
          response.EnsureSuccessStatusCode();
          string responseBody = await response.Content.ReadAsStringAsync();
          System.Console.WriteLine(responseBody);
        }
