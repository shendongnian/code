    public class Example
    {
        public IDictionary<string, string> TypeItems { get; }
          = new Dictionary<string, string>
          {
              // key part is "business" data
              // value part is for display only
              ["equals"] = "=",
              ["greaterthan"] = ">",
              ["greaterthanorequals"] = ">=",
              ["lesserthan"] = "<",
              ["lesserthanorequals"] = "<=",
          };
        public string SelectedType { get; set; }
    }
