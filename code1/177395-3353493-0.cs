    using System;
    
    public abstract class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("Result for {0}: {1}", GetType(),
                              CalledByConstructor());
        }
        
        protected abstract string CalledByConstructor();
    }
    
    public class VariableInitializer : BaseClass
    {
        private string foo = "foo";
        
        protected override string CalledByConstructor()
        {
            return foo;
        }
    }
    
    public class ConstructorInitialization : BaseClass
    {
        private string foo;
        
        public ConstructorInitialization()
        {
            foo = "foo";
        }
        
        protected override string CalledByConstructor()
        {
            return foo;
        }
    }
    
    
    public class Test
    {
        static void Main()
        {
            new VariableInitializer();
            new ConstructorInitialization();
        }
    }
