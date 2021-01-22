    // in Assembly 1
    public class Assembly1Class
    {
        public void SomeMethod()
        {
            assembly2ClassInstance.SomeAPIMethod();
        }
    }
    // in Assembly 2 (the library)
    public class Assembly2Class
    {
        public void SomeAPIMethod()
        {
            Debug.WriteLine(Assembly.GetCallingAssembly().FullName;
        }
    }
