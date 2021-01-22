    public class tx_fct {
        int _ok;
        public virtual int ok {
            get { return _ok; }
            set { _ok = value; }
        }
    }
    class custom_fct : tx_fct {
        public override int ok {
            get {
                Console.WriteLine("get");
                return base.ok;
            }
            set {
                Console.WriteLine("set");
                base.ok = value;
            }
        }
    }
