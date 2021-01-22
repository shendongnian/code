     class Apple : Fruit , ICloneable
    {
        public object Clone()
        {
            // add your code here
        }
        public override string GetColor()
        {
            return "Red";
        }
    }
