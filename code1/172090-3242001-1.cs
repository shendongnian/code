    static Message_Handler()
    {
        //here, do the registration.
        int registered = 0;
        System.Reflection.Assembly[] assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
        foreach (System.Reflection.Assembly asm in assemblies)
        {
            System.Type[] types = asm.GetTypes();
            foreach (System.Type t in types)
            {
                System.Type[] interfaces = t.GetInterfaces();
                foreach (System.Type i in interfaces)
                {
                    if (i == typeof(IMessage_Creator))
                    {
                        System.Reflection.ConstructorInfo[] constructors = t.GetConstructors();
                        foreach (System.Reflection.ConstructorInfo ctor in constructors)
                        {
                            if (ctor.GetParameters().Length == 0)
                            {
                                Add_Creator(ctor.Invoke(new object[0]) as IMessage_Creator);
                                registered++;
                            }
                        }
                    }
                }
            }
        }
        System.Diagnostics.Debug.WriteLine("registered " + registered.ToString() + " message creators.");
    }
