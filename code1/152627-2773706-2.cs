    Observable
        .Interval(TimeSpan.FromSeconds(5))
        .Select(ticks => (HttpWebRequest)WebRequest.Create("http://demicode.com"))
        .Select(request => Observable.FromAsyncPattern(request.BeginGetResponse, 
            asyncResult => 
            {
                using(var response = request.EndGetResponse(asyncResult))
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    return DateTime.Now.ToString() + sr.ReadToEnd();
                }
            }))
        .SelectMany(getContent => getContent())
        .ObserveOnDispatcher()
        .Subscribe(content => downloadContent.Text = content);
