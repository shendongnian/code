    public class Child : Father
    {
        public override Father SomePropertyName
        {
            get
            {
                return this;
            }
        }
    }
