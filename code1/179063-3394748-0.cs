     object[] objects;
     ..
     string[] result = Array.ConvertAll(objects, 
            new Converter<object, string>(Obj2string));
     public static string Obj2string(object obj)
     {
        return obj.ToString();
     }
