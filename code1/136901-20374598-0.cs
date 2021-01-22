        static void Main()
        {
            sample obj = new sample();
            Type t = obj.GetType();
            MethodInfo[] m = t.GetMethods();
            Console.WriteLine("Method Information:-\n\n");
            foreach (MethodInfo m1 in m)
                Console.WriteLine("Mthod name:" + m1.Name + "  \nMethod return type:" + m1.ReturnType + "\nIs staic:" + m1.IsStatic + "\nIs Public:" + m1.IsPublic + "\nIs Private:" + m1.IsPrivate);
            FieldInfo[] f = t.GetFields();
            Console.WriteLine("\n\nField Information:-\n\n");
            foreach(FieldInfo f1 in f)
                Console.WriteLine("Field name:" + f1.Name + "  \nField type:" + f1.FieldType + "\nIs staic:" + f1.IsStatic);
            Console.Read();
        }
