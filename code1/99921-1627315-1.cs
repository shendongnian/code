    public class TextBoxViewModel
    {
      public string Value { get; set; }
      IDictionary<string, object> moreAttributes;
      public TextBoxViewModel(string value, IDictionary<string, object> moreAttributes)
      {
        // set class properties here
      }
      public string GetAttributesString()
      {
         return string.Join(" ", moreAttributes.Select(x => x.Key + "='" + x.Value + "'").ToArray()); // don't forget to encode
      }
