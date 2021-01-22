    public class MyTextbox : Textbox
    {
      public bool IsEmpty
      { 
        get
        { 
          return String.IsNullOrEmpty(this.Text);
        }
      }
    }
