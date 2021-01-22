    public static int Dummy {
        get {
            var propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
            Console.WriteLine(propertyName);
            return 0;
        }
    }
