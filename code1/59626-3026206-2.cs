    public class Require
    {
        [ContractAnnotation("requiredCondition:false => halt")]
        public static void That(
            bool requiredCondition,
            string message = null)
        {
            ...
        }
    ...
    }
