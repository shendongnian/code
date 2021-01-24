<ol><li>Use a custom properties named for example Fields that will be a Dictionary<string, string> and to add property add it to that dictionary; Or simply instead class use dictionary. Then you when you want to get class properties you just need to iterate over that dictionary.</li>
<li>Create a class in runtime and compile it dynamically; This option is more complex, and you may prefer another options - but it enabled. For more information how to compile class dynamically, see <a href="https://stackoverflow.com/questions/3862226/how-to-dynamically-create-a-class-in-c">this question</a>. Then you can get a Type object of the class and iterate over its properties (There is the place of TypeBuilder.DefineProperty(); It define a new property to class that created in runtime).</li>
<li>Basically this option is like option 1, but if you're using C# 4+, you can use the keyword dynamic, that can be used for accessing dictionary like an object; For example, create the following class:</li></ol>
    public class DynamicDictionary : DynamicObject
    {
        private readonly Dictionary<string, object> _Dict;
    
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
            if (_Dict.TryGetValue(binder.Name, out result))
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
