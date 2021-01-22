    public abstract class BaseClass
    {
        public virtual List<string> MyParameterNames
        {
            get;
        }
    }
    
    public class DerivedClass : BaseClass
    {
        public override List<string> MyParameterNames
        {
            get
            {
                throw new Exception();
            }
        }
    }
