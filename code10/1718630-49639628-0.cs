    public class Example
    {
        public IDictionary<string, string> TypeItems { get; }
          = new Dictionary<string, string>
          {
              // key part is "business" data
              // value part is for display only
              [ "=" ] = "Equals",
              [ ">" ] = "Greater than",
              [ ">=" ] = "Greater than or equals",
              [ "<" ] = "Lesser than",
              [ ">=" ] = "Lesser than or equals",
          };
        public string SelectedType { get; set; }
    }
