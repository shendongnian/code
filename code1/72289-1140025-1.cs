     {
            Type parent = typeof(Parent);
            Type c1 = typeof(Child);
            bool isChild1  = (c1.IsSubclassOf(parent).ToString());
    
            Assembly a = Assembly.Load(File.ReadAllBytes("ClassLibrary1.dll"));
            Type c2 = a.GetType(c1.FullName);
            bool isChild2 = (c2.IsSubclassOf(parent).ToString());
        }
