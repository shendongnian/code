    public void Load()
    {
        try
        {
            Path.GetFileName("img/img");
            webBrowser1.Navigate(htmlfilewithimg);
        }
        catch(Exception ex)
        {
            webBrowser1.Navigate(htmlfilewithoutimg);
        }
    }
    
    public void Print()
    {
        webBrowser1.Print();
    }
