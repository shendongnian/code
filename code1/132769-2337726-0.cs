    public class ExternalFacing
    {
      public void MyMethod(string arg)
      {
         if (String.IsNullOrEmpty(arg))
            throw new ArgumentNullException(arg);
         implementationDependency.DoSomething(arg);
       }
    }
    internal class InternalClass
    {
        public void DoSomething(string arg)
        {
             // shouldn't have to enforce null here.
        }
    }
