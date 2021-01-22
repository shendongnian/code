    public class FooBat {
        public string Name { get; set; }
        public CharSequence Label {
            get {
                if (_label == null) {
                    _label = new DefaultCharSequence(Label);
                }
                return _label;
            }
            set { _label = value; }
        }
    }
    public class DefaultCharSequence{
        public DefaultCharSequence(CharSequence wrapped){
            this.wrapped = wrapped;
        }
    //...delegate all methods ...
        public string toString(){
            return wrapped.toString();
        }
     }
