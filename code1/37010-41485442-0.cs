    wb.Navigate(url);
    while(wb.ReadyState != WebBrowserReadyState.Complete)
    {
       Application.DoEvents();
    }
    MessageBox.Show("ok this waits Complete");
    
    //navigates to new page
    wb.Document.GetElementById("formId").InvokeMember("submit");
    while(wb.ReadyState != WebBrowserReadyState.Complete)
    {
       Application.DoEvents();
    }
    MessageBox.Show("webBrowser havent navigated  yet. it gave me previous page's html.");  
    var html = wb.Document.GetElementsByTagName("HTML")[0].OuterHtml;
