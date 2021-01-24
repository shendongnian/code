    public class Model
    {
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    [HttpPost]
    public void EmailQuote(Model model)
