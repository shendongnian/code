    var b = new B.StepClause();
    b.Action1()
        .Step("abc").Action2()
        .Action2()
        .Step("def").Action1();
        
    namespace B
    {
        public class StepClause
        {
            public StepClause Action1() { return null; }
            public StepClause Action2() { return null; }
        }
        public static class StepClauseExtensions
        {
            public static StepClause Step(this StepClause @this, string name)
            { return null; }
        }
    }
