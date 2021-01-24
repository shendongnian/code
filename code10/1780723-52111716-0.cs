    public static bool FindProperty(string className, IEnumerable<long> list)
    {
        var allSubClass = typeof(MainClass)
                             .GetMembers()
                             .Where(m => m.MemberType == System.Reflection.MemberTypes.NestedType);        
        var classLookingFor = allSubClass.FirstOrDefault(c => string.Equals(c.Name, className, System.StringComparison.InvariantCultureIgnoreCase));
        
        if (classLookingFor == null)
        {
            Console.WriteLine("Class {0} not found.", className);
            return false;
        }
        else
        {
            // get all properties, in fact they are fields type of 'long/Int64'
            var allProp = (classLookingFor as TypeInfo).DeclaredFields.Where(f => f.FieldType == typeof(long));
            var anyPropWithValue = allProp.Any(p => list.Any(lng => lng == (long)p.GetValue(null)));
            return anyPropWithValue;            
        }
    }
