    class B
    {
    
       Public sub DoSomethingOnA(IA a )
       {
            a.DoSomething();
       }
    
    }
    
    Interface IA
    {
        void DoSomething();
    }
    
    Class A : IA
    {
        void DoSomething()
       {
           //
       }
    
    }
