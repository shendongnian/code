    class Fruit
    {
        public virtual string GetColor()
        {
            return string.Empty;
        }
    }
    class Apple : Fruit
    {
        public override string GetColor()
        {
            return "Red";
        }
    }
    class Banana : Fruit
    {
        public override string GetColor()
        {
            return "Yellow";
        }
    }
