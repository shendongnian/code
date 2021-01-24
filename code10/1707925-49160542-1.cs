    public class MyClass : IMyClassPublic, IMyClassInternal
    {
        public void PublicMethod() {  }
        void IMyClassInternal.InternalMethod() {  }
    }
