    public class Fruits
    {
        public string Fruit { get; set; }
        public Color Color { get; set; }
        public string ColorStr { get { return Color.ToString(); } }
        public Fruits(string fruit, Color color)
        {
            Fruit = fruit;
            Color = color;
        }
    }
