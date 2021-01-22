    class LocalImageBrush : MarkupExtension
    {
      public string Filename { get; set; }
    
      public override object ProvideValue(IServiceProvider serviceProvider)
      {
        var result = new Uri("file:///" + ProfileDirectory.LocalDataPath + "/" + Filename);
        return new ImageBrush(new BitmapImage(result));
      }
    }
