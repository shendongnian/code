    [ComVisible(true)]
    public class Foo
    {
      public Foo(HtmlDocument doc) 
      {
        IHTMLDocument2 doc2 = (IHTMLDocument2)doc.DomDocument;
        doc2.onkeydown = this;
      }
    
      [System.Runtime.InteropServices.DispId(0)]
      public void EventHandler()
      {
        IHTMLWindow2 win2 = (IHTMLWindow2)_doc.Window.DomWindow;
        IHTMLEventObj e = win2.@event;
    
        if (e.keyCode == (int)Keys.F5)
        {
          // ...
        }
      }
    }
   
