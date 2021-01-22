    wb.Navigate(url);
    while(wb.ReadyState != WebBrowserReadyState.Complete)
    {
         Application.DoEvents();
    }
    MessageBox.Show("Loaded");
