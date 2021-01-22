    public class BoolWrapper
    {
         public bool Value { get; set; }
         public BoolWrapper (bool value) { this.Value = value; }
    }
    BoolWrapper a = new BoolWrapper(false);
    BoolWrapper b = a;
    b.Value = true; 
     // a.Value == true 
