    public class MyFactory : IFactory
    {
        private IDependency dependency;
        public MyFactory(IDependency dependency)
        {
            if (dependency == null)
            {
                throw new ArgumentNullException("dependency");
            }
        
            this.dependency = dependency;
        }
        #region IFactory Members
        public MyClass Create(string data)
        {
            return new MyClass(this.dependency, data);
        }
        #endregion
    }
