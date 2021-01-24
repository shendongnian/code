    public class SweetViewModel
        {
            //From Sweet Model
            public int SweetID { get; set; }
            public int CategoryID { get; set; }
            public Category Category { get; set; }
            public string SweetName { get; set; }
            public bool Singular { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
    
            //From Cart Model
            public int Qty { get; set; }
        }
