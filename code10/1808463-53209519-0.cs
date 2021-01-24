    public class BaseType
    {
        public virtual void Method1(String typeName)
             //^^^^^^^ This
        {
            MessageBox.Show("Base method 1 + Type: "+typeName);
        }
    }
    
    public class DerivedType : BaseType
    {
        public override void Method1(String typeName)
             //^^^^^^^^ And this
        {
            MessageBox.Show("Derived method 1 + Type: "+typeName);
        }
    }
