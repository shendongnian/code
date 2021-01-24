    public struct Example
    {
         public string SomeProperty {get;set;}
         public Example(string propValue) : this()
         {
             SomeProperty = propValue;
         }
         public void Assign(string newPropertyValue)
         {
             this = new Example(newPropertyValue);
         }
    }
