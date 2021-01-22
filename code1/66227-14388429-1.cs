    public class Settings
    {
         public XmlUri Uri { get; set; }
    }
    ...
    var s = new Settings { Uri = new Uri("http://www.example.com") };
