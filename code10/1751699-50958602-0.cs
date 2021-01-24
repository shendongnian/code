    public class BoxPlotSeries
        {
            public string color { get; set; }
            public string name { get; set; }
            public Data data { get; set; }
    
            public class Data
            {
                public decimal Low { get; set; }
    
                public decimal Q1 { get; set; }
    
                public decimal Median { get; set; }
    
                public decimal Q3 { get; set; }
    
                public decimal High { get; set; }
            }
        }
