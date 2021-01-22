    public void CopySelectedSlidesToClipboard() {
      // Construct data format for Slide collection
      DataFormats.Format dataFormat = DataFormats.GetFormat( typeof( List<Slide> ).FullName );
     
      // Construct data object from selected slides
      IDataObject dataObject = new DataObject();
      
      List<Slide> dataToCopy = SelectedSlides.ToList();
      dataObject.SetData( dataFormat.Name, false, dataToCopy );
     
      // Put data into clipboard
      Clipboard.SetDataObject( dataObject, false );
    }
     
    public void PasteSlidesFromClipboard() {
      // Get data object from the clipboard
      IDataObject dataObject = Clipboard.GetDataObject();
      if( dataObject != null ) {
        // Check if a collection of Slides is in the clipboard
        string dataFormat = typeof( List<Slide> ).FullName;
        if( dataObject.GetDataPresent( dataFormat ) ) {
          // Retrieve slides from the clipboard
          List<Slide> slides = dataObject.GetData( dataFormat ) as List<Slide>;
          if( slides != null ) {
            Slides = Slides.Concat( slides ).ToList();
          }
        }
      }
    }
