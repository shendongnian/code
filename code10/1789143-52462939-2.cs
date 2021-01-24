    public class ModelStep {
        public string StepName { get; set; }
        public string Prompt { get; set; }
        public bool IsOptional {get; set;}
        public UserInputType InputType { get; set; }
        public TypeValidator BasicValidator { get; set; }
        public SpecificValidator AdditionalValidator { get; set; }
        public Action <List<Answer>, string> AfterInputAction { get; set; }
        public Func<List<Answer>, string, string> EvalNextStep { get; set; }
    }
