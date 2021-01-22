    public interface IPrivateField
    {
        bool IsDirty { get;}
    }
    public interface IPublicField : IPrivateField
    {
        new bool IsDirty { get; set; }
    }
    public class Whatever : IPublicField
    {
        public bool IsDirty 
        {
            get
            {
                // logic here
            }
            set
            {
                // logic here
            }
        }
    }
