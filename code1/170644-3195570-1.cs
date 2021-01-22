    public class Car
    {
        public int RegNum { get; private set; }
        public Color Color { get; set; }
        public Car(int regNum)
            : this(regNum, Color.Empty)
        { }
        public Car(int regNum, Color color)
        {
            RegNum = regNum;
            Color = color;
        }
    }
