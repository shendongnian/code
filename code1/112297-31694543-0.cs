    Public Class MyClass{
       public int Id{get;set;}
       public String PropertyA{get;set;}
       public override string ToString()
       {
         return this.Id+ "," + this.PropertyA;
       }
    }
