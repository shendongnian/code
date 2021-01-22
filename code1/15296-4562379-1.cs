    // In MyClassMyAspect1.cs
    public partial class MyClass{ 
    
        public void MyClass_MyAspect2(){  
            ... normal construction goes here ...
            
        }
    
    }
    // In MyClassMyAspect2.cs
    public partial class MyClass{ 
    
        public void MyClass_MyAspect1(){  
            ... normal construction goes here ...
        }
    }
    // In MyClassConstructor.cs
    public partial class MyClass : IDisposable { 
    
        public MyClass(){  
           GetType().GetMethods().Where(x => x.Name.StartsWith("MyClass"))
                                 .ForEach(x => x.Invoke(null));
        }
        public void Dispose() {
           GetType().GetMethods().Where(x => x.Name.StartsWith("DisposeMyClass"))
                                 .ForEach(x => x.Invoke(null));
        }
        
    }
