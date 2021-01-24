    class SimpleDocumentViewModel : IAuthorViewModel
    {
          view GetView()
          {
              ... do document specific stuff
              ... return view
          }
    }
    
    class ExtendedDocumentViewModel : IAuthorViewModel
    {
          int ExtraData { get; set; }
          int MoreExtraData { get; set; }
          view GetView()
          {
              ... do document specific stuff
              ... return view
          }
    }
    
    interface IAuthorViewModel
    {
        view GetView();
    }
