    public class DesignerHappy
    {
        private ADesignerHappyImp imp_;
    
        public int MyMethod()
        {
            return imp_.MyMethod()    
        }
    
        public int MyProperty
        {
            get { return imp_.MyProperty; }
            set { imp_.MyProperty = value; }
        }
    }
    
    public abstract class ADesignerHappyImp
    {
        public abstract int MyMethod();
        public int MyProperty {get; set;}
    }
