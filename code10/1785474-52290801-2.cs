    class Tabletop : Rectangle 
    {
        private double cost;
        public Tabletop(double l, double w) : base(l, w) { }
        public double GetCost() 
        {
            double cost;  // this hides the field
            cost = GetArea() * 70;
            return cost;  // this referts to the variable defined two lines above
        }
        public void Display() 
        {
            Console.WriteLine("Cost: {0}", cost); // while this refers to the field
        }
    }
