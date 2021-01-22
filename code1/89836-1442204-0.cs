    HtmlElementCollection elements = this.webBrowser.Document.Body.All;
    foreach(HtmlElement element in elements){
       string nameAttribute = element.GetAttribute("Name");
       if(!string.IsNullOrEmpty(nameAttribute) && nameAttribute == section){
          element.ScrollIntoView(true);
          break;
       }
    }
