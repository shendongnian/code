    class TestClass{
        public int Property1{get;set}
        public int Property2{get;set}
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(TestClass))
                return false;
            var convertedObj = (TestClass)obj;
            return (convertedObj.Property1 == this.Property1 && convertedObj.Property2 == this.Property2);
        }
    }
