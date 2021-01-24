	public partial class ValidationErrors {
        public string Message { get; set; }
        public ModelState ModelState { get; set; }
    }
    public partial class ModelState : Dictionary<string, List<string>> {
    }
