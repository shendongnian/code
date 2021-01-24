    interface IComponent { }
    
    enum Appearance : byte
    {
        Human,
        Monster,
        SparksFlyingAround,
        FlyingArrow
    }
    
    class VisibleComponent : IComponent
    {
        public Appearance Appearance { get; set; }
    }
    
    class PhysicalComponent : IComponent
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
