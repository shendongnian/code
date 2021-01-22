    public class myRow{
      private string _key;
      public string key
      {
         get
         {
            return _key;
         }
      }
      private string _value;
      public string value
      {
         get
         {
            return _value;
         }
      }
      public myRow( string Key, string Value )
      {
         _key = Key;
         _value = Value;
      }
  }
