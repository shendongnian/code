    public static class Tools
    {
        public static XElement AsXml(this object input)
        {
            return input.AsXml(string.Empty);
        }
        public static XElement AsXml(this object input, string name)
        {
            if (string.IsNullOrEmpty(name))
                name = input.GetType().Name;
            var xname = XmlConvert.EncodeName(name);
            if (input == null)
                return new XElement(xname);
            if (input is string || input is int || input is float /* others */)
                return new XElement(xname, input);
            var type = input.GetType();
            var fields = type.GetFields(BindingFlags.Instance |
                                        BindingFlags.NonPublic)
                             .Union(type.GetFields(BindingFlags.Instance |
                                                   BindingFlags.Public));
            var elems = fields.Select(f => f.GetValue(input)
                                            .AsXml(f.Name));
            return new XElement(xname, elems);
        }
        public static void ToObject(this XElement input, object result)
        {
            if (input == null || result == null)
                throw new ArgumentNullException();
            var type = result.GetType();
            var fields = type.GetFields(BindingFlags.Instance |
                                        BindingFlags.NonPublic)
                             .Union(type.GetFields(BindingFlags.Instance |
                                                   BindingFlags.Public));
            var values = from elm in input.Elements()
                         let name = XmlConvert.DecodeName(elm.Name.LocalName)
                         join field in fields on name equals field.Name
                         let backType = field.FieldType
                         let val = elm.Value
                         let parsed = backType.AsValue(val, elm)
                         select new
                         {
                             field,
                             parsed
                         };
            foreach (var item in values)
                item.field.SetValue(result, item.parsed);            
        }
        public static object AsValue(this Type backType,
                                          string val,
                                          XElement elm)
        {
            if (backType == typeof(string))
                return (object)val;
            if (backType == typeof(int))
                return (object)int.Parse(val);
            if (backType == typeof(float))
                return (float)int.Parse(val);
            object ret = FormatterServices.GetUninitializedObject(backType);
            elm.ToObject(ret);
            return ret;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var obj = new { Matt = "hi", Other = new { ID = 1 } };
            var other = new { Matt = "zzz", Other = new { ID = 5 } };
            var ret = obj.AsXml();
            ret.ToObject(other);
            Console.WriteLine(obj); //{ Matt = hi, Other = { ID = 1 } }
            Console.WriteLine(other); //{ Matt = hi, Other = { ID = 1 } }
        }
    }
