    static void Main(string[] args)
        {
            Assembly asm = null;
            string assemblyPath = @"C:\works\...\StaticMembers.dll" 
            string classFullname = "StaticMembers.MySingleton";
            string doSomethingMethodName = "DoSomething";
            string doSomethingElseMethodName = "DoSomethingElse";
            
            asm = Assembly.LoadFrom(assemblyPath);
            if (asm == null)
               throw new FileNotFoundException();
            Type[] types = asm.GetTypes();
            Type theSingletonType = null;
            foreach(Type ty in types)
            {
                if (ty.FullName.Equals(classFullname))
                {
                    theSingletonType = ty;
                    break;
                }
            }
            if (theSingletonType == null)
            {
                Console.WriteLine("Type was not found!");
                return;
            }
            MethodInfo doSomethingMethodInfo = 
                        theSingletonType.GetMethod(doSomethingMethodName );
            FieldInfo field = theSingletonType.GetField("instance", 
                               BindingFlags.Static | BindingFlags.Public);
            object instance = field.GetValue(null);
            string msg = (string)doSomethingMethodInfo.Invoke(instance, Type.EmptyTypes);
            Console.WriteLine(msg);
            MethodInfo somethingElse  = theSingletonType.GetMethod(
                                           doSomethingElseMethodName );
            msg = (string)doSomethingElse.Invoke(instance, Type.EmptyTypes);
            Console.WriteLine(msg);}
