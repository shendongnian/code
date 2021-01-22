    class a {
       public void GetA(){
         // some logic here
       }
    }
    
    class b {
        private _a=new a();
        public void GetB()
        {
             _a.GetA();
        } 
    }
