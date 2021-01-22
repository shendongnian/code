    public MyClass
    {
       private ISomeDependency m_dependencyThatWillBeUsedMuchLater 
       // passing a null ref here will cause 
       // an exception with a meaningful stack trace    
       public MyClass(ISomeDependency dependency)
       {
          if(dependency == null) throw new ArgumentNullException("dependency");
          m_dependencyThatWillBeUsedMuchLater = dependency;
       }
       
       // Used later by some other code, resulting in a NullRef
       public ISomeDependency Dep { get; private set; }
    }
