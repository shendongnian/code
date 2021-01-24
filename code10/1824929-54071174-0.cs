    [Property(Arbitrary = new[] { typeof(MyArbitraries) })]
    public void ValueBetweenMinAndMax((DateTimeOffset minValue, DateTimeOffset maxValue) bounds)
    {
        // ...
    }
    public static class MyArbitraries
    {
        public static Arbitrary<(DateTimeOffset minValue, DateTimeOffset maxValue)> DateTimeOffsetBounds()
        {
            return (from minValue in Arb.Generate<DateTimeOffset>()
                    from maxValue in Arb.Generate<DateTimeOffset>()
                    where minValue <= maxValue
                    select (minValue, maxValue))
                .ToArbitrary();
        }
    }
