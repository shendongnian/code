    class Foo
    {
        [TestDataFile(Name = "lol")]
        public void SomeMethod()
        {
            var attribute = Helper.GetAttribute();
            Console.WriteLine(attribute.Name);
        }
    
        [TestDataFile(Name = "XD")]
        public void SomeOtherMethod()
        {
            var attribute = Helper.GetAttribute();
            Console.WriteLine(attribute.Name);
        }
    }
