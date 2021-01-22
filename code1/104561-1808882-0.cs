    Assembly a = Assembly.Load(brockenAssembly);
    
    Module[] mList = a.GetModules();
    
    for (int i = 0; i < mList.length; i++)
    {
         Module m = a.GetModules()[i];
         Type[] tList = m.GetTypes();
    
    }
