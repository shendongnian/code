    class MyClass
    {
       public string Prop{ get; set; }
       // ... snip ...
       public bool IsValid
       {
          bool valid = false;
          if((value != null) && 
          (!string.IsNullOrEmpty(value.Prop)) && 
          (possibleValues.Contains(value.prop)))
          {
             valid = true
          }
          return valid;
       }
       // ...snip...
    }
