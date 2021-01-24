    public class Main
    {
        // All shared properties and methods here
    }
    public class Middle1 : Main
    {
        public void Method1()  
    }
    public class Middle2 : Main
    {
        public void Method2()  
    }
    public class Sub1 : Middle1
    {
        // Don't have access to Method2()  
    }
    public class Sub2 : Middle2
    {
        // Don't have access to Method1()  
    }
