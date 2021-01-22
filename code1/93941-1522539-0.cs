    static void Main(string[] args)
    {
        int blinkCount = 300, redPercent = 10, greenPercent = 90;
        List<BlinkObject> blinks = new List<BlinkObject>(300);
    
        for (int i = 0; i < (blinkCount * redPercent / 100); i++)
        {
            blinks.Add(new BlinkObject("red"));
        }
    
        for (int i = 0; i < (blinkCount * greenPercent / 100); i++)
        {
            blinks.Add(new BlinkObject("green"));
        }
    
        blinks.Sort();
    
        foreach (BlinkObject b in blinks)
        {
            Console.WriteLine(b);
        }
    }
    
    class BlinkObject : IComparable<BlinkObject>
    {
        object Color { get; set; }
        Guid Order { get; set; }
    
        public BlinkObject(object color)
        {
            Color = color;
            Order = Guid.NewGuid();
        }
    
        public int CompareTo(BlinkObject obj)
        {
            return Order.CompareTo(obj.Order);
        }
    
        public override string ToString()
        {
            return Color.ToString();
        }
    }
