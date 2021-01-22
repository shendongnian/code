    public class TextBoxViewModel
    {
      public string Value { get; set; }
      IDictionary<string, object> moreAttributes;
      public TextBoxViewModel(string value, IDictionary<string, object> moreAttributes)
      {
        // set class properties here
        moreAttributes = new Dictionary<string, object>();
      }
      
      public TextBoxViewModel Attr(string name, object value)
      {
         moreAttributes[name] = value;
         return this;
      }
   }
       // and in the view
       <%= Html.EditorFor(x => new TextBoxViewModel(x.StringValue).Attr("class", "myclass").Attr("size", 15) %>
