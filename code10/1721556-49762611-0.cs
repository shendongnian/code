    public interface IDependency {
        string SomeMethod();
    }
    public MyClass {
        public bool MyMethod(IDependency input) {            
            var value = input.SomeMethod();
            
            var result = "Output" + value.ToUpper(); //<-- value should not be null
            
            return result != null;
        }
    }
