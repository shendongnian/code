    class C : I
    {
     public A TheObject {get;set;} 
     B I.TheObject 
     {
       get { return A; }
       set { A = value as A; }
     }
    }
