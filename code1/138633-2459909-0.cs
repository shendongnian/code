    var a = new A.NamedStepClause();
    a.Action1()
        .Step("abc").Action2()
        .Action2()
        .Step("def").Action1();
        
        
    namespace A
    {
        public class StepClause<SC> where SC : StepClause<SC>
        {
            public SC Action1() { return null; }
            public SC Action2() { return null; }
        }
        public class NamedStepClause : StepClause<NamedStepClause>
        {
            public NamedStepClause Step(string name) { return null; }
        }
    }
