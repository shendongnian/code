    Doc theDoc = new Doc();
    int theID;
    theDoc.Page = theDoc.AddPage();
    theID = theDoc.AddImageHtml(htmlOutput);
     while (true)
     {
         theDoc.FrameRect(); // add a black border
         if (!theDoc.Chainable(theID))
             break;
          theDoc.Page = theDoc.AddPage();
          theID = theDoc.AddImageToChain(theID);
     }
     for (int i = 1; i <= theDoc.PageCount; i++)
     {
        theDoc.PageNumber = i;
        theDoc.Flatten();
      }
      //reset back to page 1 so the pdf starts displaying there
      if(theDoc.PageCount > 0)
           theDoc.PageNumber = 1;
      //now get your pdf content from the document
      byte[] theData = theDoc.GetData();
