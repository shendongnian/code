    public class MySettings
    {
      // the one and only instace (the singleton):
      public static readonly MySettings Instance = new MySettings();
      private MySettings() {} // private constructor
    
      public int SomeNumber { get; set; }
      public string SomeString { get; set; }
    }
