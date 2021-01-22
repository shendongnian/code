    var stats = list.Aggregate(
                         StatsAggregate.Default,
                         (a, v) => a.ProcessValue(v));
    if (stats.Sum > 100.0)
    {
        list[stats.MaxIndex] -= (stats.Sum - 100.0);
    }
    else if (stats.Sum < 100.0)
    {
        list[stats.MinIndex] += (100.0 - stats.Sum);
    }
    ...
    struct StatsAggregate
    {
        public static StatsAggregate Default
        {
            get
            {
                return new StatsAggregate
                {
                    Sum = 0,
                    Min = double.MaxValue,
                    MinIndex = -1,
                    Max = double.MinValue,
                    MaxIndex = -1
                };
            }
        }
    
        private int currentIndex;
        
        public double Sum { get; private set; }
        public double Min { get; private set; }
        public double Max { get; private set; }
        public int MinIndex { get; private set; }
        public int MaxIndex { get; private set; }
    
        public StatsAggregate ProcessValue(double value)
        {
            return new StatsAggregate
            {
                Sum = this.Sum + value,
                Max = Math.Max(this.Max, value),
                MaxIndex = value > this.Max ? currentIndex : MaxIndex,
                Min = Math.Min(this.Min, value),
                MinIndex = value < this.Max ? currentIndex : MinIndex,
                currentIndex = currentIndex + 1
            };
        }
    }
