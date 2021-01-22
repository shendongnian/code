    public static int? FindClosestTo(this IEnumerable<int> numbers, int targetNumber)
    {
        var minimumDistance = numbers.Select(number => new NumberDistance(x, number)).Min();
        return minimumDistance == null ? (int?) null : minimumDistance.Number;
    }
    private class NumberDistance : IComparable<NumberDistance>
    {
        internal NumberDistance(int targetNumber, int number)
        {
            this.Number = number;
            this.Distance = Math.Abs(targetNumber - number);
        }
        internal int Number { get; private set; }
        internal int Distance { get; private set; }
        public int CompareTo(NumberDistance other)
        {
            var comparison = this.Distance.CompareTo(other.Distance);
            if(comparison == 0)
            {
                // When they have the same distance, pick the number closest to zero
                comparison = Math.Abs(this.Number).CompareTo(Math.Abs(other.Number));
                if(comparison == 0)
                {
                    // When they are the same distance from zero, pick the positive number
                    comparison = this.Number.CompareTo(other.Number);
                }
            }
            return comparison;
        }
    }
