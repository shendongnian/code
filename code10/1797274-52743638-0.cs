    // Alias for delegate function
    using Condition = Func<int, bool>;
    class SomeStateClass
    {
        public void SomeFuncToCreateConditionList()
        {
            List<Condition> conditions = new List<Condition>
            {
                new Condition(x => x > 5),
                new Condition(x => x > 5 * x)
            };
        }
    }
