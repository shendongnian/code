    public class Weapon : ICloneable
    {
        public string Name;
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public Weapon Clone()
        {
            return (Weapon)this.MemberwiseClone();
        }
    }
