    public BaseClass<T> : BaseClass {
        public T Value {get;set;}
        public override object ValueAsObject {
           get{return (T)this.Value;} 
           set{this.Value = value;} // or conversion, e.g. string -> int
    }
