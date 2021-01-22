    public static void ListArrayListMembers(ArrayList list)
    {
        foreach (Object obj in list)
        {
            Type type = obj.GetType();
            Console.WriteLine("{0} -- ", type.Name);
            Console.WriteLine(" Properties: ");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Console.WriteLine("\t{0} {1} = {2}", prop.PropertyType.Name, 
                    prop.Name, prop.GetValue(obj, null));
            }
            Console.WriteLine(" Fields: ");
            foreach (FieldInfo field in type.GetFields())
            {
                Console.WriteLine("\t{0} {1} = {2}", field.FieldType.Name, 
                    field.Name, field.GetValue(obj));
            }
        }
    }
