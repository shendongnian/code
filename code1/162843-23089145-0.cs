    private bool FindFirst(string text)
      {
         var doc = (IHTMLDocument2)WebBrowser.Document.DomDocument;
         var sel = (IHTMLSelectionObject)doc.selection;
         sel.empty(); // get an empty selection, so we start from the beginning
         var rng = sel.createRange() as IHTMLTxtRange;
         if (rng != null && rng.findText(text, 1000000000, 0))
         {
            rng.select();
            rng.scrollIntoView(false);
            return true;
         }
         return false;
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="text"></param>
      /// <returns></returns>
      public bool FindNext(string text)
      {
         var doc = (IHTMLDocument2)WebBrowser.Document.DomDocument;
         var sel = (IHTMLSelectionObject)doc.selection;
         var rng = sel.createRange() as IHTMLTxtRange;
         if (rng != null)
         {
            rng.collapse(false); // collapse the current selection so we start from the end of the previous range
            if (rng.findText(text, 1000000000, 0))
            {
               rng.select();
               rng.scrollIntoView(false);
               return true;
            }
            else
               return FindFirst(text);
         }
         return false;
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="text"></param>
      /// <returns></returns>
      public bool FindPrevious(string text)
      {
         var doc = (IHTMLDocument2)WebBrowser.Document.DomDocument;
         var sel = (IHTMLSelectionObject)doc.selection;
         var rng = sel.createRange() as IHTMLTxtRange;
         if (rng != null)
         {
            
            rng.collapse(true); // it should be true,so it goes to start of the document
            var found = rng.findText(text, -1, 0); // Range count value should give negative value
            if(!found)
            {
               rng.moveEnd("textedit");
               found = rng.findText(text, -1, 0);
            }
            if (found)
            {
               rng.select();
               rng.scrollIntoView(false);
               return true;
            }
         }
         return false;
      }
