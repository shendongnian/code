    public class MyCustomPrincipal : IPrincipal
    {
        public MyCustomPrincipal Current { get; }
        public bool HasCurrent { get; }
        public void SetAsCurrent();
    }
