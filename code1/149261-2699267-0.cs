    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        public class Box
        {
            public string Id { get; set; }
            public List<Item> Items {get;set;}
        }
    
        public class Item
        {
            public int Id { get; set; }
    
            public int Firmness { get; set; }
            public int Elasticity { get; set; }
            public int Strength { get; set; }
            public double Price { get; set; }
    
            public int FirmnessWt { get; set; }
            public int ElasWt { get; set; }
            public int StrWt { get; set; }
    
            public int ItemScore
            {
                get
                {
                    return
                        (Firmness * FirmnessWt) +
                        (Elasticity * ElasWt) +
                        (Strength * StrWt);
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                // set the rankings
                int firmnessWt = 20;
                int elasWt = 40;
                int strWt = 80;
    
                // generate the items
                Item item1 = new Item { Id = 1, Elasticity = 1, Firmness = 4, Strength = 2, ElasWt=elasWt, FirmnessWt=firmnessWt, StrWt=strWt };
                Item item2 = new Item { Id = 2, Elasticity = 2, Firmness = 3, Strength = 4, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item3 = new Item { Id = 3, Elasticity = 3, Firmness = 2, Strength = 1, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item4 = new Item { Id = 4, Elasticity = 4, Firmness = 1, Strength = 3, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
    
                Item item6 = new Item { Id = 6, Elasticity = 1, Firmness = 5, Strength = 2, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item7 = new Item { Id = 7, Elasticity = 1, Firmness = 4, Strength = 4, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item8 = new Item { Id = 8, Elasticity = 1, Firmness = 3, Strength = 1, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item9 = new Item { Id = 9, Elasticity = 2, Firmness = 2, Strength = 3, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item10 = new Item { Id = 10, Elasticity = 2, Firmness = 3, Strength = 2, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item11 = new Item { Id = 11, Elasticity = 2, Firmness = 2, Strength = 4, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item12 = new Item { Id = 12, Elasticity = 3, Firmness = 6, Strength = 1, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
    
                Item item13 = new Item { Id = 13, Elasticity = 3, Firmness = 5, Strength = 4, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item15 = new Item { Id = 15, Elasticity = 2, Firmness = 4, Strength = 5, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item16 = new Item { Id = 16, Elasticity = 3, Firmness = 2, Strength = 5, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item20 = new Item { Id = 20, Elasticity = 3, Firmness = 1, Strength = 7, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
                Item item21 = new Item { Id = 21, Elasticity = 3, Firmness = 1, Strength = 4, ElasWt = elasWt, FirmnessWt = firmnessWt, StrWt = strWt };
    
                // populate the 3 boxes with the generated items
                List<Box> boxes = new List<Box>
                {
                    new Box
                    {
                        Id = "A",
                        Items = new List<Item> { item1, item2, item3, item4 }
                    },
                    new Box
                    {
                        Id="B",
                        Items = new List<Item> { item6, item7, item8, item9, item10, item11, item12 }
                    },
                    new Box
                    {
                        Id="C",
                        Items = new List<Item> { item13, item15, item16, item20, item21 }
                    }
                };
    
                // calculate top candidate for firmness
                List<Item> items = boxes.SelectMany(c => c.Items).ToList();
    
                Item firmnessCandidate = items.OrderByDescending(a => a.Firmness).First();
    
                // calculate top candidate for elasticity
                Item elasticityCandidate = items.OrderByDescending(b => b.Elasticity).First();
    
    
                // calculate top candidate for strength
                Item strengthCandidate = items.OrderByDescending(c => c.Strength).First();
    
                // calculate top candidate by combined weight
                Item weightCandidate = items.OrderByDescending(w => w.ItemScore).First();
    
                Console.WriteLine("Firmness - id:" + firmnessCandidate.Id.ToString() + ", score: " + firmnessCandidate.Firmness.ToString());
                Console.WriteLine("Elasticity - id:" + elasticityCandidate.Id.ToString() + ", score: " + elasticityCandidate.Elasticity.ToString());
                Console.WriteLine("Strength - id:" + strengthCandidate.Id.ToString() + ", score: " + strengthCandidate.Strength.ToString());
                Console.WriteLine("Item score - id:" + weightCandidate.Id.ToString() + ", score: " + weightCandidate.ItemScore.ToString());
    
                Console.ReadLine();
            }
        }
    }
