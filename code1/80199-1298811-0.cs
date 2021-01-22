    public class PhoneNumber {
      public override string ToString() { /*...*/ }
      public Parse(string val) { /*...*/ }
      public string Value {
        get {
          return ToString();
        }
        set {
          Parse(value);
        }
      }
    }
