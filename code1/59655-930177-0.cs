    public class Circle
    {
        public virtual float Radius { get; set; }
        public Circle(float radius)
        {
            Radius = radius;
        }
    }
    public class NullCircle : Circle
    {
        public override float Radius 
        { 
            get { return float.NaN; }
            set { }
        }
        public NullCircle() { }
    }
