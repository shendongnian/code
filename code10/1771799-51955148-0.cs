    dynamic body = webBrowser1.Document.Body.DomElement;
    dynamic controlRange = body.createControlRange();
    dynamic element = webBrowser1.Document.GetElementById("hplogo").DomElement;
    controlRange.add(element);
    controlRange.execCommand("Copy", false, null);
    pictureBox1.Image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
