    public class SomeClass
    {
       public string GetValue() { return "some string"; }
       public void SetValue(string arg)
       { 
           SetValue(arg); // recursively calls itself until stackoverflow
       }
    }
