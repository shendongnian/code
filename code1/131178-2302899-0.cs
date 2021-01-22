    public class MyClass 
    { 
      private int _myHeight; 
      public event EventHandler Changed;
      protected void OnChanged() {
        if (Changed != null) Changed(this, EventArgs.Empty);
      }
     
      public int myHeight 
      { 
        get { return myHeight; } 
        set {
          myHeight = value; 
          OnChanged();
        } 
      }
      // Repeat the same pattern for all other properties
    } 
