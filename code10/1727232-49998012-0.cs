    class A
    {
         public int i;
         public A()
         {
             i = 10;
         }
         public override bool Equals(object o)
         {
             return (o as A)?.i == this.i;
         }
         public override int GetHashCode()
         {
             return i.GetHashCode();
         }
     }
