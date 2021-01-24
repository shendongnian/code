    public async Task FillResults()
    {
          foreach( var urlx in Urls)
          {
                jobs.Add(
                          GetResponse(urlx, (response) =>
                          {
                            if (response != null && response.StatusCode==200)
                            {
                                Result result=new Result;
                                result.Value=response.SomeValue;
                                result.url=urlx;------>It is important that SomeValue corresponds to urlx and not other say,urly
                                results.Add(result);
                            }
                          })
                       );
          }
          await Task.WhenAll(jobs);
          //Or Task.WhenAll(jobs).ContinueWith({AN ACTION CALLBACK}) 
          //if you want to keep the return as a void;
    }
