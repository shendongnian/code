    WebBrowser wb = new WebBrowser();
    //Setting the page height and width to a reasonable number. So that whatever the content loaded in it gets aligned properly.
    //For me 3000 works fine for my requirements.
    wb.Width = 3000; 
    wb.Height = 3000;
    
    wb.Url = new Uri(htmlFilePath);
    //the below code will force the webbrowser control to load the html in it.
    while (wb.Document.Body == null)
    {
        Application.DoEvents();
    }
    int height = wb.Document.Body.ScrollRectangle.Height;
