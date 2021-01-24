    public class A
    {
        public A(IDependencyB dependencyB)
        {
            System.Diagnostics.Debug.Print(dependencyB.Name);
        }
    }
