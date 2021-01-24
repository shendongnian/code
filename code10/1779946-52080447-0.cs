    var program = new Program();
    foreach (FieldInfo field in typeof(Program).GetFields())
    {
        foreach (Attribute attr in field.GetCustomAttributes())
        {
            if (attr is SerializedAttribute)
            {
                Console.WriteLine("\t" + "Variable name: " + field.Name + 
                    "\t" + "Variable value:" + field.GetValue(program));
            }
        }
    }
