    public class A
    {
          int var1;
          int var2;
    
          public A(int var1, int var2)
          {
                this.var1 = var1;
                this.var2 = var2;
          }
          public void Method1(int i)
          {
                var1 = i;
          }
          public int Method2()
          {
                return var1+var2;
          }
    }
