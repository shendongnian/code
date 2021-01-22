    abstract class Base 
    {
     protected int myInt;
     protected abstract void setMyInt();
    }
    
    class Derived : Base 
    {
     override protected void setMyInt()
     {
       myInt = 3;
     }
    }
