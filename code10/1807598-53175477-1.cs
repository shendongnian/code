    public static class PropertyCheckTester
    {
        public static void Test()
        {
            var test = new TestPropertyCheck();
            test.AllPropertiesSet += AllPropertiesSet;
            Debug.WriteLine("Setting Name");
            test.Name = "My Name";
            Debug.WriteLine("Setting ID");
            test.Id = 42;
            Debug.WriteLine("Setting Address");
            test.Address = "Your address goes here";
        }
        public static void AllPropertiesSet(object sender, EventArgs args)
        {
            Debug.WriteLine("All Properties Set");
        }
    }
