    public class NullableDictionnary : Dictionary<string, string>{
    string null_value;
    public StringDictionary this[string key]{
        get{
            if ( key == null ) 
                {return null_value;}
            return base[key];
        }
        set{
            if ( key == null ) 
                {null_value = value;} 
            else 
                {base[key] = value;}
        }
    }
