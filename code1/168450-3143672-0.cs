    public enum SportType
    {
        Soccer, Football, ...
    }
    public sealed class Foo
    {
        private static readonly IDictionary<SportType, Int32> sportTypeScoreMap =
            new Dictionary<SportType, Int32>
            {
                { Soccer, 30 },
                { Football, 20 },
                ...
             }
        public Int32 GetScore(SportType sportType)
        {
            return Foo.sportTypeScoreMap[sportType];
        }
    }
