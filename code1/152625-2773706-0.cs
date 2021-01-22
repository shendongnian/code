    var req = (HttpWebRequest)WebRequest.Create("http://demicode.com");
    var resultObservable = Observable
                .FromAsyncPattern(req.BeginGetResponse, ar => 
                    {
                        var resp = req.EndGetResponse(ar);
                        using (var sr = new StreamReader(resp.GetResponseStream()))
                        {
                            return sr.ReadToEnd();
                        }
                    });
    
    var resultObservable = resultObservableFactory();
    
    resultObservable
        .ObserveOnDispatcher()
        .Subscribe(result => downloadContent.Text = result);
