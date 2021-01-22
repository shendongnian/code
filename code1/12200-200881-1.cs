        public struct Unit
        {   // the conversion operator...
            public static implicit operator Unit(int value)
            {
                return new Unit(value);
            }
            // the boring stuff...
            private readonly int value;
            public int Value { get { return value; } }
            public Unit(int value) { this.value = value; }
        }
