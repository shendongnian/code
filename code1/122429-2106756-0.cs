    public class PinnacleStock : ICloneable
    {
        public PinnacleStock Clone()
        {
            return (PinnacleStock)this.MemberwiseClone();
        }
        // Other methods
    }
