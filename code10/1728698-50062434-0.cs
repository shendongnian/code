    public class Faq
    {
         public int nodeId { get; set; }
         public string question { get; set; }
         public string answer { get; set; }
    }
    
    public class FaqCollection
    {
         public IList<Faq> faqs { get; set; }
    }
