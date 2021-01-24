           .
           .
           .
          //Create and object of the relevant generic class
           ClassName<string> d = new ClassName<string>();
           // Get a Type object representing the constructed type.
           Type constructed = d.GetType();
           Type generic = constructed.GetGenericTypeDefinition();
           DisplayTypeInfo(generic);
        }
        private static void DisplayTypeInfo(Type t)
        {
            Console.WriteLine("\r\n{0}", t);
            Console.WriteLine("\tIs this a generic type definition? {0}", 
                t.IsGenericTypeDefinition);
            Console.WriteLine("\tIs it a generic type? {0}", 
                t.IsGenericType);
            Type[] typeArguments = t.GetGenericArguments();
            Console.WriteLine("\tList type arguments ({0}):", typeArguments.Length);
            foreach (Type tParam in typeArguments)
            {
                Console.WriteLine("\t\t{0}", tParam);
            }
        }
