    public class Car: ICloneable
    {
        public int TopSpeed{ get; set; }
        public object Clone()
        {
            return new Car() { TopSpeed = this.TopSpeed };
        }
    }
