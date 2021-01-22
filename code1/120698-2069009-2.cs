    public class ExampleRecord
    {
       public bool IsWriteable {get;set;}
    
       private string _nameField;
       public string NameField
       {
           get {return _nameField;}
           set {if(IsWriteable) _nameField = value;}
       }
    }
