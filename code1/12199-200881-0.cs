       struct Unit
        {
            private readonly int value;
            public int Valuee { get { return value; } }
            public Unit(int value) { this.value = value; }
            public static implicit operator Unit(int value)
            {
                return new Unit(value);
            }
        }
