    public class Parent 
    { 
        public virtual void Print() 
        { 
            Console.WriteLine("Parent"); 
        } 
    } 
     
    public class Child : Parent 
    { 
        public override void Print() 
        { 
            Console.WriteLine("Child"); 
        } 
    } 
