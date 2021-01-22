    public class MyCustomGrid : GridView
    {
      [...]
      private MyCustomSettings customSettings;
      [PersistenceMode(PersistenceMode.InnerProperty),DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public MyCustomSettings CustomSettings
            {
                get { return customSettings; }
            }
      [...]
    }
    
    [TypeConverter(typeof(MyCustomSettings))]
    public class MyCustomSettings 
    {
      private string cssClass = "default";
      public string CssClass
      {
        get { return cssClass; }
        set { cssClass = value; }
      }
    }
