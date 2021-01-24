    public class MyViewModel
    {
        public int PageId { get; set; }
        [UIHint("MYContent")]
        public IList<ContentElement> ContentElements { get; set; }
    }
