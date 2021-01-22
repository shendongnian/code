    Properties expose fields.  Fields should (almost always) be kept private to a class and accessed via get and set properties.  Properties provide a level of abstraction allowing you to change the fields while not affecting the external way they are accessed by the things that use your class.
    
    public class MyClass {
       // this is a field.  It is private to your class and stores the actual data.
       private string _myField;
       
       // this is a property.  When you access it uses the underlying field, but only exposes
       // the contract that will not be affected by the underlying field
       public string MyField {
         get {
           return _myField;
         }
         set {
           _myField = value;
         }
       }
    }
