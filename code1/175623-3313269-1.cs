    public class whatever
    {
        public string WhateverId { get; private set; }
        public static whatever Create(string whateverId)
        {
            return new whatever() { WhateverId = whateverId };
        }
    }
