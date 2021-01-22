    class A 
    {
        private B b;
 
        public A()
        {
            this.b = new B();
        }
        public void SetValue() 
        { 
            this.b.Test = 10;
        } 
    } 
     
    class B 
    { 
       int test; 
       public int Test
       {
           get{ return this.test; }
           set{ this.test = value; }
       }    
    } 
