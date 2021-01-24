    IHTMLElement2 body = (IHTMLElement2)webBrowser1.Document.Body.DomElement;
    IHTMLControlRange controlRange = (IHTMLControlRange)body.createControlRange();
    IHTMLControlElement element = (IHTMLControlElement)webBrowser1.Document
        .GetElementById("imgCaptcha").DomElement;
    controlRange.add(element);
    controlRange.execCommand("Copy", false, null);
    pictureBox1.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap); 
