    public static async Task<string> GetStringAsync(string path)
    {
      try
      {
        Func<Task<string>> func = () =>
        {
          var response = await Client.GetAsync(path);
          var responsestring = await response.Content.ReadAsStringAsync();
          return responsestring;
        };
        var task = func();
        return await Task.WhenAny(task, Task.Delay(20000)) == task
            ? await task
            : RequestTimeOutMessage;
      }
      catch (Exception e)
      {
        return e.GetBaseException().Message;
      }
    }
