    enum FoodType
    {
        Tea = 2
    }
    class FoodItem
    {
        public string Text { get; set; }
        public FoodType FoodType { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
