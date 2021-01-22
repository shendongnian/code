    public class MyClass
    {
        private readonly ISomeInterface dependency;
        public MyClass(ISomeInterface dependency)
        {
            if(dependency == null)
            {
                throw new ArgumentNullException("dependency");
            }
            this.dependency = dependency;
        }
        // use this.dependency in other members
    }
