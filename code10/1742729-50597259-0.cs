    public void BeginTest(Action<ProxyStatus> callback, int timeout = 10000)
    {
        var action = new Action(() =>
        {
            var req = HttpWebRequest.Create(URL);
            req.Timeout = timeout;
    
            WebHelper.BeginGetResponse(req, new Action<RequestCallbackState>(callbackState =>
            {
                if (callbackState.Exception != null)
                {
                    callback(ProxyStatus.Invalid);
                }
                else
                {
                    var responseStream = callbackState.ResponseStream;
                    using (var reader = new StreamReader(responseStream))
                    {
                        var responseString = reader.ReadToEnd();
                        if (responseString.Contains(Validation))
                        {
                            callback(ProxyStatus.Valid);
                        }
                        else
                        {
                            callback(ProxyStatus.Invalid);
                        }
                    }
                }
            }));
        });
    
        action.BeginInvoke(null, null);
    }
