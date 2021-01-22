    class SomeClass
    {
        public static void VerifyNullArgument(params object objects)
        {
            foreach(object obj in objects)
                if(obj == null) throw new ArgumentNullException(obj.ToString());
        }
    }
