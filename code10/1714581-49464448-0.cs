    Assembly/Project1
    
    public class ClassA {
        private string variable1;
        protected string variable2;
        public string variable3;
        internal string variable4;
        
        public void MyFancyProcess()
        {
            Console.Write(variable1);
        }
    }
    	
    public class ClassB : ClassA {
        protected string variable2;
        public string variable3;
        
        private void DoSomeStuff()
        {
            Console.Write(variable1); // This would raise an error, its is private and only could be called from ClassA *even if ClassB is child of ClassA*
            Console.Write(variable2); // I can access variable2 because it is protected *AND ClassB is child of ClassA*
            Console.Write(variable3); // This would work, public has no restrictions
            Console.Write(variable4); // This would work, ClassB and ClassA share same assembly
        }
    }
    
    internal class ClassC
    {
        ClassA myAClassInstance = new ClassA();
        
        Console.Write(myAClassInstance.variable1); This would raise an error, it is exclusive to ClassA and we are in ClassC
        Console.Write(myAClassInstance.variable2); This would raise an error, because ClassC does not inherit ClassA
        Console.Write(myAClassInstance.variable3);
        Console.Write(myAClassInstance.variable4); This would work, ClassC and ClassA share same assembly
    }
    Assembly/ProjectB
    
    public class ClassC : ClassA // Please note that if ClassA where not public it would raise an error
    {
        public void ExecuteMyLogic()
        {
           Console.Write(variable1); // This would raise an error, its is private and only could be called from ClassA
            Console.Write(variable2); // I can access variable2 because it is protected *AND ClassC is child of ClassA despite being a different assembly*
            Console.Write(variable3); // This would work, public has no restrictions
            Console.Write(variable4); // This would raise an error, they are different assemblies
        }
    }
