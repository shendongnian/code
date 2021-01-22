    public class Bla : ICloneable
    {
        string _someFieldToClone;
    
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    
        public Bla Clone()
        {
            return (Bla)MemberwiseClone();
        }
    }
