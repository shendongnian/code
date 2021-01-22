    public void attachEventHandler(HTMLDocument doc)
    {
      IHTMLElementCollection els = doc.all;
      foreach (IHTMLElement el in els)
      {
        if(el.tagName == "INPUT")
        {
          DispHTMLInputElement inputElement = el as DispHTMLInputElement;
          if (inputElement.type != "text" && inputElement.type != "password")
          {
            HTMLButtonElementEvents_Event htmlButtonEvent = inputElement as HTMLButtonElementEvents_Event;
            htmlButtonEvent.onclick += new HTMLButtonElementEvents_onclickEventHandler(buttonElement_HTMLButtonElementEvents_Event_onclick);
          }
        }
      }
     }
