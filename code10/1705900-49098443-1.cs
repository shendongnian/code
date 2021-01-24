    public async Task<string> Get()
    {
      var context = this.Request.GetOwinContext();
      var token = context.Get<CancellationToken>("RequestTerminated");
      // simulate long async call
      await Task.Delay(10000, token);
      token.ThrowIfCancellationRequested();
      return "Hello !";
    }
