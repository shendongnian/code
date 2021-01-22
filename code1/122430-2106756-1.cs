    public class PinnacleStock : ICloneable
    {
        public PinnacleStock Clone()
        {
            return (PinnacleStock)this.MemberwiseClone();
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        // Other methods
    }
