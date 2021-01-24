    public class C1
    {
        ...
        public List<StatusChoices> ChoiceList { get; set; }
        public C1() // Constructor. Is run when a new C1 object is created with `new`.
        {
            ChoiceList = new List<StatusChoices>();
        }
        ...
    }
