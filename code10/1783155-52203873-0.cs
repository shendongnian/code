    public class A 
    {
           public int PropertyA {get; set;}
           public B B {get; set;}
    }
----------
    public class B 
    {
           public int PropertyB {get; set;}
           public A A {get; set;}
    }
    
