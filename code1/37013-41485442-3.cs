        public myForm1 {
    
        	myForm1_load() { }
        	
            // func to make browser wait is inside the Extended class More tidy.
    	    WebBrowserEX wbEX = new WebBrowserEX();
    
    		button1_click(){
    	        wbEX.Navigate("site1.com");
    	        wbEX.waitWebBrowserToComplete(wb);
    
    	        wbEX.Document.GetElementById("input1").SetAttribute("Value", "hello");
    	        //submit does navigation
    	        wbEX.Document.GetElementById("formid").InvokeMember("submit");
    	        wbEX.waitWebBrowserToComplete(wb);
    	        // this actually waits for document Compelete. worked for me.
    
    	        var processedHtml = wbEX.Document.GetElementsByTagName("HTML")[0].OuterHtml;
    	        var rawHtml = wbEX.DocumentText;
    		 }
    	 }
        
    //put this  extended class in your code.
    //(ie right below form class, or seperate cs file doesnt matter)
    public class WebBrowserEX : WebBrowser
    {
       //ctor
       WebBrowserEX()
       {
       	 //wired aumatically here. we dont need to worry our sweet brain.
         this.DocumentCompleted += (o, e) => { webbrowserDocumentCompleted = true;};
       }
    	 //instead of checking  readState, get state from DocumentCompleted Event 
         // via bool value
    	 bool webbrowserDocumentCompleted = false;
    	 public void waitWebBrowserToComplete()
         {
           while (!webbrowserDocumentCompleted )
           { Application.DoEvents();  }
    	   webbrowserDocumentCompleted = false;
    	 }
    
     }
