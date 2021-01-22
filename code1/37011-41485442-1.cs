     button1_click(){
            wb.Navigate("site1.com");
            waitWebBrowserToComplete(wb);
            wb.Document.GetElementById("input1").SetAttribute("Value", "hello");
            //submit does navigation
            wb.Document.GetElementById("formid").InvokeMember("submit");
            waitWebBrowserToComplete(wb);
            // this actually waits for document Compelete. worked for me.
        
            var processedHtml = wb.Document.GetElementsByTagName("HTML")[0].OuterHtml;
            var rawHtml = wb.DocumentText;
     }
   
     //instead of checking  readState . we get state from DocumentCompleted Event via bool value
     bool webbrowserDocumentCompleted = false;
     public static void waitWebBrowserToComplete(WebBrowser wb)
     {
         while (!webbrowserDocumentCompleted )
         {
             Application.DoEvents();
         }
         webbrowserDocumentCompleted = false;
      }
      
      form_load(){
         wb.DocumentCompleted += (o, e) => {
            webbrowserDocumentCompleted = true;
          };
      }
