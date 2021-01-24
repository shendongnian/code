        public struct IncomePerHour : IComparable<IncomePerHour>
        {
            public int Income { get; set; }
            public int Hour { get; set; }
            public int CompareTo(IncomePerHour other)
            {
                return Income.CompareTo(other.Income); 
            }
        }
