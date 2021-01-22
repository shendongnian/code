    foreach (Object obj in list) {
        Type type = obj.GetType();
    
        foreach (var f in type.GetFields().Where(f => f.IsPublic)) {
            Console.WriteLine("Name: " + f.Name + "  Value:" + f.GetValue(obj).ToString());
        }							
    }
