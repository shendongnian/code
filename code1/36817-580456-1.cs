    public interface Label{
        string getLabel();
        boolean isDefault(); //or isValued() or use instanceof expressions
    }
    public interface Nameable{
        string getName();
    }
    public class FooBat implements Nameable {
        public string Name { get; set; }
        public Label Label {
            get {
                if (_label == null) {
                    _label = new DefaultLabel(this);
                }
                return _label;
            }
            set { _label = value; }
        }
    }
    public class DefaultLabel implements Label{
        public DefaultCharSequence(Nameable named){
            this.named = named;
        }
    
        public string getLabel(){
            return named.getName();
        }
        public boolean isDefault(){ return true; }
     }
     public class StringLabel implements Label {
         ...
     }
