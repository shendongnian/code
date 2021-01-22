    WebBrowser wb = new WebBrowser(); wb.Navigate("about:blank");
    string url=@"http:\\....";
    wb.Navigate(url);
    private const int sleepTimeMiliseconds = 200;
    while (wb.ReadyState != WebBrowserReadyState.Complete)
    {
    Thread.Sleep(sleepTimeMiliseconds);
    Application.DoEvents();
    }
    
    wb.Document.ExecCommand("SelectAll", false, null);
    wb.Document.ExecCommand("Copy", false, null);
    richtextbox.Paste();
