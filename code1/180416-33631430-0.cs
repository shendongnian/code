    public class QuoteViewModel : IQuoteViewModel
    {
        public QuoteViewModelProducts Products { get; set; }
        public bool HasDiscount { get; set; }
        public string Product { get; set; }
        public DetailButtonType Button { get; set; }
    }
    public enum DetailButtonType
    {
        Buy,
        Callback,
        Email
    }
