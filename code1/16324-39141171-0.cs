    struct Day
    {
        readonly int day;
        private Day(int day)
        {
            this.day = day;
        }
        
        public static implicit operator int(Day value)
        {
           return value.day;
        }
   
        public static implicit operator Day(int value)
        {
           return new Day(value);
        }
        public static readonly Day Monday = 0;
        public static readonly Day Tuesday = 1;
        public static readonly Day Wednesday = 2;
        public static readonly Day Thursday = 3;
        public static readonly Day Friday = 4;
        public static readonly Day Saturday = 5;
        public static readonly Day Sunday = 6;
       }
    }
