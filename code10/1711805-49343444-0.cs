    public static async Task<string> GetStringAsync(string path)
    {
      try
      {
        var task = DoGetStringAsync(path);
        return await Task.WhenAny(task, Task.Delay(20000)) == task
            ? await task
            : RequestTimeOutMessage;
      }
      catch (Exception e)
      {
        return e.GetBaseException().Message;
      }
    }
    private async Task<string> DoGetStringAsync(string path)
    {
      var response = await Client.GetAsync(path);
      var responsestring = await response.Content.ReadAsStringAsync();
      return responsestring;
    }
