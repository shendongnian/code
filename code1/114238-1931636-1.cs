    public class Video  // ideally implement INotifyPropertyChanged - not shown
    {
      public Uri PreviewUri { get; set; }
      public Uri SourceUri { get; set; }
    
      public static ObservableCollection<Video> LoadVideoInfo()
      {
        /* pseudocode
        new up a collection
        foreach (file in videoFolder)
          collection.Add(new Video { PreviewUri = smallFileUri, SourceUri = bigFileUri });
        return collection;
        */
      }
    }
