    using System;
    
    namespace ClassLibrary1
    {
        public class SameAssemblyBaseClass
        {
            public string publicVariable = "public";
            protected string protectedVariable = "protected";
            protected internal string protected_InternalVariable = "protected internal";
            internal string internalVariable = "internal";
            private string privateVariable = "private";
            public void test()
            {
                // OK
                Console.WriteLine(privateVariable);
                
                // OK
                Console.WriteLine(publicVariable);
    
                // OK
                Console.WriteLine(protectedVariable);
    
                // OK
                Console.WriteLine(internalVariable);
                
                // OK
                Console.WriteLine(protected_InternalVariable);
            }
        }
    
        public class SameAssemblyDerivedClass : SameAssemblyBaseClass
        {
            public void test()
            {
                SameAssemblyDerivedClass p = new SameAssemblyDerivedClass();
                
                // NOT OK
                // Console.WriteLine(privateVariable);
                
                // OK
                Console.WriteLine(p.publicVariable);
    
                // OK
                Console.WriteLine(p.protectedVariable);
    
                // OK
                Console.WriteLine(p.internalVariable);
    
                // OK
                Console.WriteLine(p.protected_InternalVariable);
            }
        }
    
        public class SameAssemblyDifferentClass
        {
            public SameAssemblyDifferentClass()
            {
                SameAssemblyBaseClass p = new SameAssemblyBaseClass();
                
                // OK
                Console.WriteLine(p.publicVariable);
    
                // OK
                Console.WriteLine(p.internalVariable);
    
                // NOT OK
                // Console.WriteLine(privateVariable);
                
                // Error : 'ClassLibrary1.SameAssemblyBaseClass.protectedVariable' is inaccessible due to its protection level
                //Console.WriteLine(p.protectedVariable);
    
                // OK
                Console.WriteLine(p.protected_InternalVariable);
            }
        }
    }
    
--------------------------------------------------------------------------------
   
     using System;
            using ClassLibrary1;
            namespace ConsoleApplication4
        
    {
        class DifferentAssemblyClass
        {
            public DifferentAssemblyClass()
            {
                SameAssemblyBaseClass p = new SameAssemblyBaseClass();
                
                // NOT OK
                // Console.WriteLine(p.privateVariable);
    
                // NOT OK
                // Console.WriteLine(p.internalVariable);
    
                // OK
                Console.WriteLine(p.publicVariable);
    
                // Error : 'ClassLibrary1.SameAssemblyBaseClass.protectedVariable' is inaccessible due to its protection level
                // Console.WriteLine(p.protectedVariable);
                
                // Error : 'ClassLibrary1.SameAssemblyBaseClass.protected_InternalVariable' is inaccessible due to its protection level
                // Console.WriteLine(p.protected_InternalVariable);
            }
        }
    
        class DifferentAssemblyDerivedClass : SameAssemblyBaseClass
        {
            static void Main(string[] args)
            {
                DifferentAssemblyDerivedClass p = new DifferentAssemblyDerivedClass();
                
                // NOT OK
                // Console.WriteLine(p.privateVariable);
               
                // NOT OK
                //Console.WriteLine(p.internalVariable);
                
                // OK
                Console.WriteLine(p.publicVariable);
                
                // OK
                Console.WriteLine(p.protectedVariable);
                
                // OK
                Console.WriteLine(p.protected_InternalVariable);
    
                SameAssemblyDerivedClass dd = new SameAssemblyDerivedClass();
                dd.test();
            }
        }
    }
    
     
