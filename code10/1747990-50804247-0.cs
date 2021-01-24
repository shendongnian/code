    public class Fabric
        {
            public int FabricId { get; set; } //Item Number
    
            // public int MainCategoryId { get; set; }
            // public virtual MainCategory MainCategory { get; set; }
    
            public int SubCategory1Id { get; set; }
            public virtual SubCategory1 SubCategory1 { get; set; }
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public string Location { get; set; }
            public string Type { get; set; } //Knit, Woven, Voile, Interfacing, Denim, Suiting, etc.
            public string Weight { get; set; }//Lightweight, Medium, Heavy
            public string Content { get; set; }//Cotton, Polyester, Nylon, etc.
            public string Design { get; set; }//Marvel Comics, Amy Butler, etc.
            public string Brand { get; set; } //Springs Creative Products, Free Spirit, Robert Kaufman, etc.
            public double Quantity { get; set; }//.25 yd, .50 yd, .75 yd, 1.0 yd, etc.
            public int Width { get; set; }// in inches, ie. 44", 54", etc.
            public string Source { get; set; }//Joann
            public string Notes { get; set; }
            public List<string> Tags { get; set; }
            public int ItemsSold { get; set; }
            public virtual ICollection<Purchase> Purchases { get; set; }
        }
