    public class TestResult
    {
        public string TestDescription { get; set; }
        public ExpectationResult RequiredExpectationResult { get; set; }
        public ExpectationResult NonRequiredExpectationResult { get; set; }
        /* *** added these new property getters *** */
        public string RequiredExpectationResultDescr { get { return this.RequiredExpectationResult.GetDescription(); } }
        public string NonRequiredExpectationResultDescr { get { return this.NonRequiredExpectationResult.GetDescription(); } }
    }
