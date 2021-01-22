    public abstract class ChildOneAnnoying : Parent {
        protected virtual int PropertyOneImpl {
            get { return base.PropertyOne; }
            set { base.PropertyOne = value; }
        }
        protected override int PropertyOne {
            get { return PropertyOneImpl; }
            set { PropertyOneImpl = value; }
        }
    }
    public class ChildOne : ChildOneAnnoying {
        public new int PropertyOne {
            get { return PropertyOneImpl; }
            set { PropertyOneImpl = value; }
        }
    }
