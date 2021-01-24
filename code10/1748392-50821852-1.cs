    class SimpleDocumentViewModel : IAuthorViewModel
    {
          public viewType1 view {get;set;}
          public SimpleDocumentViewModel(viewType1 viewIn,etc...)
          {
              view = viewIn;
          } 
          view GetView()
          {
              return view.GetView();
          }
    }
    
    class ExtendedDocumentViewModel : IAuthorViewModel
    {
          int ExtraData { get; set; }
          int MoreExtraData { get; set; }
          public viewType2 view {get;set;}
          public ExtendedDocumentViewModel(viewType2 viewIn,etc...)
          {
              view = viewIn;
          } 
          view GetView()
          {
              return view.GetView(ExtraData,MoreExtraData);
          }
    }
    
    interface IAuthorViewModel
    {
        view GetView();
    }
