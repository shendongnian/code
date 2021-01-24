    var html = RunWBControl("http://google.com").Result;
----
    static public Task<string> RunWBControl(string url)
    {
        var tcs = new TaskCompletionSource<string>();
        var th = new Thread(() =>
        {
            WebBrowserDocumentCompletedEventHandler completed = null;
            using (WebBrowser wb = new WebBrowser())
            {
                completed = (sndr, e) =>
                {
                    tcs.TrySetResult(wb.DocumentText);
                    wb.DocumentCompleted -= completed;
                    Application.ExitThread();
                };
                wb.DocumentCompleted += completed;
                wb.Navigate(url);
                Application.Run();
            }
        });
        th.SetApartmentState(ApartmentState.STA);
        th.Start();
        return tcs.Task;
    }
