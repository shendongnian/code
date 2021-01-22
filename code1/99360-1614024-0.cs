    public class foo
    {
       public static foo Current { get; private set; }
    
       public foo()
       {
           foo.Current = this;
       }
       
       public void SetString(string foo)
       {
           label1.Text = foo;
       }
    }
