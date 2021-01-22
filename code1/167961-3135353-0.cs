    public ClassWithMoo
    {
       private string moo;
       public string Moo
       {
          get
          { 
             if (String.IsNullOrEmpty(this.moo)) this.moo = "Baa";
             return this.moo; 
          }
          set
          {
             this.moo = value;
          }
       }
    }
    public ClassThatUsesMoo
    {
        ClassWithMoo cow = new ClassWithMoo();
        // breakpoint here would show cow.Moo = "Baa" 
        // This is because the debugger/watch window will instantiate the property!
        someCodeHere();
        cow.Moo = "Moo"; 
        debug.WriteLine(cow.Moo); // outputs 'Moo' now that it has been set properly
    }
