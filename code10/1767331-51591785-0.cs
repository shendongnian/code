    public class DynamicDictionary : DynamicObject
    {
        Dictionary<string, object> _Dict;
    
        public DynamicDictionary(Dictionary<string, object> dict)
        {
            _Dict = dict;
        }
    
        public DynamicDictionary()
        {
            _Dict = new Dictionary<string, object>();
        }
    
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _Dict[binder.Name] = value;
            return true;
        }
    
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_Dict.TryGetValue(binder.name, out result))
            {
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
    }
    dynamic dict = new DynamicDictionary();
    dict.Property = "Value";
    dict.Num = 123;
    Console.WriteLine(dict.Property);
    Console.WriteLine(dict.NonExistProperty); // Will throw an exception
