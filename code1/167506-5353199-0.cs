    class WibbleBO
    {
        public static WibbleBO FromData(WibbleDTO data)
        {
            return new WibbleBO
            {
                Val1 = data.Val1,
                Val2 = data.Val2,
                Val3 = ... // and so on..
            };
        }
    }
