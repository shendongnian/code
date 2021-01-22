    public class Require
    {
        [AssertionMethod]
        public static void That(
            [AssertionCondition(AssertionConditionType.IS_TRUE)] 
            bool requiredCondition,
            string message = null)
        {
            ...
        }
    ...
    }
