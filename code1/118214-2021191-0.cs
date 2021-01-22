    class A 
    { 
        protected int a; 
        protected char b; 
        public virtual void Show() 
        { 
            a=5; 
            MessageBox.Show(""+a); 
        } 
    } 
    
    class B:A 
    { 
         public override void Show() 
         { 
             b='z'; 
             MessageBox.Show(""+a+ ""+b); 
         } 
    } 
