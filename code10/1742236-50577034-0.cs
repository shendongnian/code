    public frmMain()
    {
    	website.DocumentCompleted += website_DocumentCompleted;
    }
    
    
    public void website_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) 
    {
    	website.Document.GetElementById("search").InnerText = "Cavaliers vs Boston highlights"
    }
