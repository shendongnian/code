    public class DisplayTextAttribute : Attribute {
      public DisplayTextAttribute(String text) {
      Text = text;
      }
      public string Text { get; set; }
    }
