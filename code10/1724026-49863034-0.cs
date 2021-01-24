    public interface IDoughArgs
    {
    }
    public class NYPizzaDoughArgs : IDoughArgs
    {
        public enum DoughTypes
        {
            Thin = 0,
            Thick = 1
        }
        public DoughTypes DoughType { get; set; }
    }
