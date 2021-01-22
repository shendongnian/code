    webBrowser.DocumentCompleted += (o, e) =>
    {
        webBrowser.Document.Window.Error += (w, we) =>
        {
            we.Handled = true;
    
            // Do something with the error...
            Debug.WriteLine(
                string.Format(
                   "Error: {1}\nline: {0}\nurl: {2}",
                   we.LineNumber, //#0
                   we.Description, //#1
                   we.Url));  //#2
        };
    };
