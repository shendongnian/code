     //intialize the TesseractEngine
      using (var engine = new TesseractEngine("path to tessdata folder", "eng", EngineMode.Default))
      {
          //image here is Bitmap on which OCR is to be performed
          using (var page = engine.Process(image, PageSegMode.Auto))
          {
              using (var iterator = page.GetIterator())
              {
            
                  iterator.Begin();
                  do
                  {
                      string currentWord = iterator.GetText(PageIteratorLevel.Word);
                      //do something with bounds 
                      iterator.TryGetBoundingBox(PageIteratorLevel.Word, out Rect bounds);                                   
                   }
                   while (iterator.Next(PageIteratorLevel.Word));
              }
          }
       }
