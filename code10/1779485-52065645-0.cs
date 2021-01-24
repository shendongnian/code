    //added to support inner implementation 
    interface IModelImpl {
     void Do();
    }
    
    class A: IModelImpl
    {
        public long id { get; set; }
        public string description { get; set; }
        public string code { get; set; }
    
        public void Do(){
            console.WriteLine(this.description);
        }
    }
    
    class B: IModelImpl
    {
        public long someID { get; set; }
        public void Do(){
            console.WriteLine(this.someID);
        }
    }
    
    class C: IModelImpl
    {
        public long anydesign { get; set; }
        public void Do(){
            ...
        }
    }
  
