    public class BaseClass {
        public string Prop1 {get; set;}
    } 
    public class ChildClass : BaseClass {
        
        public ChildClass() : base() {}
        
        public ChildClass(BaseClass baseClassObject) : base() {
            this.Prop1 = baseClassObject.Prop1;
        }
        
        public string Prop2 { get; set; }
    }
    
