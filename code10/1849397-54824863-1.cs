    class MyClass
    {
        public int Var1 {get;set;}
        public int Var2 {get;set;}
        public int Var3 {get;set;}
        public int Var4 {get;set;}
        public MyClass(){
            
        }
    }
    void Main()
    {
       var myClass = new MyClass
       {
         Var1 = 1,
         Var2 = 2,
         Var3 = 3,
       };
    }
