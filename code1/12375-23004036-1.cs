    Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse,
                                        request.EndGetResponse,
                                        null)
        .ContinueWith(task =>
        {
            var response = (HttpWebResponse) task.Result;
            Debug.Assert(response.StatusCode == HttpStatusCode.OK);
        });
