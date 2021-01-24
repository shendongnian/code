    //Public Class MYControl : Usercotrol 
    public class MYControl : UserControl 
    {
        public ListItem Language {get; set;}
    }
    // Associate the TypeConverter with the Type, not property
    [TypeConverter(typeof(ListItemConverter))]
    public class ListItem
    {
        public string Name {get; set;}
        public string Value {get; set;}
        
        // serialization will need this
        public ListItem()
        { }
        public ListItem(string name, string value)
        {
            Value = value;
            Name = name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
