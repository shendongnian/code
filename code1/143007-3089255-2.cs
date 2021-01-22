    private void AddStyles()
    {
    	try
    	{
    		if (_webBrowser.Document != null)
    		{
    			IHTMLDocument2 currentDocument = (IHTMLDocument2)_webBrowser.Document.DomDocument;
    
    			int length = currentDocument.styleSheets.length;
    			IHTMLStyleSheet styleSheet = currentDocument.createStyleSheet(@"", length + 1);
    			//length = currentDocument.styleSheets.length;
    			//styleSheet.addRule("body", "background-color:blue");
    			TextReader reader = new StreamReader(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "basic.css"));
    			string style = reader.ReadToEnd();
    			styleSheet.cssText = style;
    
    		}
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    }
