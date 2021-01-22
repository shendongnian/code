        public static void Call()
        {
            StackTrace stackTrace = new StackTrace();
            var methodName = stackTrace.GetFrame(1).GetMethod();
            var className = methodName.DeclaringType.Name.ToString();
            Console.WriteLine(methodName.Name + "*****" + className );
        }
