    class Program
        {
            static void Main(string[] args)
            {
                var testCases = new List<TestClass>()
                {
                    new JoinTestClassOrig(),
                    new JoinTestClassHash_mjwills(),
                    new JoinTestClassHashMe(),
                    new JoinTestClassMergeMe(),
                };
                Stopwatch stopwatch = new Stopwatch();
                List<List<ProductPurchaseOutp>> results = new List<List<ProductPurchaseOutp>>();            
    
                for (int i = 0; i < 5; i++)
                {
                    foreach (var testClass in testCases)
                    {                   
                        testClass.GenerateRandomObjects(1);
                        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                        GC.Collect();
                        GC.WaitForFullGCComplete();
    
                        stopwatch.Restart();
                        var res = (testClass.ComputeMatches());
                        stopwatch.Stop();
    
                        if (i > 0)
                        {
                            results.Add(res);
                            testClass.results.Add(stopwatch.ElapsedMilliseconds);
                        }
                    }
                }
    
                Console.WriteLine("Checking results...");
    
    
                int cnt = results
                    .Select(r => r
                        .OrderBy(o => o.ProductID)
                        .ThenBy(o => o.ROQ)
                        .ThenBy(o => o.RPQ)
                        .ThenBy(o => o.RUQ)
                        .ThenBy(o => o.RV)
                        .ToList()
                    )
                    .Aggregate((a, b) =>
                {
                    for (int i = 0; i < a.Count; ++i)
                    {
                        if (!a[i].IsEqualTo(b[i])) { throw new Exception("Sequences are not equal"); }
                    }
                    return a;
                }).Where(m => m.WAP != 0).Count();
    
    
                Console.WriteLine("Count: " + cnt.ToString());
    
                foreach (var test in testCases)
                {
                    Console.WriteLine(test.name() + " avg: " + (int)test.results.Average() + " / rounds: " + string.Join(", ", test.results));
                }
    
                Console.ReadLine();
            }
    
    
        }
    
        public abstract class TestClass
        {
            protected List<ProductPurchase> ListOne = new List<ProductPurchase>();
            protected List<ProductPurchase> ListTwo = new List<ProductPurchase>();
    
            public List<long> results = new List<long>();
    
            public void GenerateRandomObjects(int seed)
            {
                Random rnd = new Random(seed);
    
                ListOne.Clear();
                ListTwo.Clear();
    
                for (int i = 0; i < 500000; i++)
                {
                    ListOne.Add(new ProductPurchase
                    {
                        ProductID = rnd.Next(1, 300000),
                        Price = rnd.Next(1, 100),
                        Quantity = rnd.Next(1, 30),
                        GlobalQuantity = rnd.Next(1, 5000)
                    });
    
                    ListTwo.Add(new ProductPurchase
                    {
                        ProductID = rnd.Next(1, 300000),
                        Price = rnd.Next(1, 100),
                        Quantity = rnd.Next(1, 30),
                        GlobalQuantity = rnd.Next(1, 10000)
                    });
                }
            }
    
            public abstract List<ProductPurchaseOutp> ComputeMatches();
    
            public  string name()
            {
                return this.GetType().Name;
            }
        }
    
        public class JoinTestClassOrig : TestClass
        {
            public override List<ProductPurchaseOutp> ComputeMatches()
            {
                var matched = (from listOne in ListOne
                               join listTwo in ListTwo on listOne.ProductID equals listTwo.ProductID into matches
                               select new ProductPurchaseOutp
                               {
                                   ProductID = listOne.ProductID,
                                   ROQ = listOne.Price,
                                   RUQ = listOne.Quantity,
                                   RPQ = listOne.GlobalQuantity,
                                   RV = listOne.Price * listOne.Quantity * listOne.GlobalQuantity,
                                   BMPProduct = matches.OrderBy(m => m.Price).FirstOrDefault(),
                                   WAP = (matches.IsEmpty() || matches.Sum(m => m.Quantity * m.GlobalQuantity) == 0) ? 0 : matches.Sum(m => m.Quantity * m.GlobalQuantity * m.Price) / matches.Sum(m => m.Quantity * m.GlobalQuantity)
                               })
                             .ToList();
    
                return matched;
            }
        }
    
        public class JoinTestClassHash_mjwills : TestClass
        {
            public override List<ProductPurchaseOutp> ComputeMatches()
            {
                var dicTwo = ListTwo.ToLookup(z => z.ProductID);
    
                var matched = (from listOne in ListOne
                               let matches = dicTwo[listOne.ProductID]
                               let sum = matches.Sum(m => (long)m.Quantity * m.GlobalQuantity)
                               select new ProductPurchaseOutp
                               {
                                   ProductID = listOne.ProductID,
                                   ROQ = listOne.Price,
                                   RUQ = listOne.Quantity,
                                   RPQ = listOne.GlobalQuantity,
                                   RV = listOne.Price * listOne.Quantity * listOne.GlobalQuantity,
                                   BMPProduct = matches.OrderBy(m => m.Price).FirstOrDefault(),
                                   WAP = sum == 0 ? 0 : matches.Sum(m => m.Quantity * m.GlobalQuantity * m.Price) / sum
                               });
    
                return matched.ToList();
            }
        }
    
        public class JoinTestClassMergeMe : TestClass
        {
            private IEnumerable<ProductPurchaseOutp> matched()
            {
                var l1 = ListOne
                    .OrderBy(p => p.ProductID);
    
                var l2 = ListTwo
                    .OrderBy(p => p.ProductID);
    
                bool eo2 = false;
    
                using (var en1 = l1.GetEnumerator())
                using (var en2 = l2.GetEnumerator())
                {
                    if (!en1.MoveNext()) { yield break; }
                    var cur1 = en1.Current;
                    ProductPurchase cur2 = null;
                    if (en2.MoveNext())
                    {
                        cur2 = en2.Current;
                    }
                    else
                    {
                        eo2 = true;
                    }
    
    
                    do
                    {
                        int ID = cur1.ProductID;
    
                        long qsum = 0;
                        decimal psum = 0;
                        decimal min = decimal.MaxValue;
                        decimal wap = 0;
                        ProductPurchase minp = null;
                        while (!eo2 && cur2.ProductID <= ID)
                        {
                            if (cur2.ProductID == ID)
                            {
                                long quantity = (long)cur2.Quantity * cur2.GlobalQuantity;
                                var price = cur2.Price;
                                qsum += quantity;
                                psum += quantity * price;
                                if (price < min)
                                {
                                    minp = cur2;
                                    min = price;
                                }
                            }
                            if (en2.MoveNext())
                            {
                                cur2 = en2.Current;
                            }
                            else
                            {
                                eo2 = true;
                            }
                        };
    
                        if (qsum != 0)
                        {
                            wap = psum / qsum;
                        }
    
                        do
                        {
                            yield return new ProductPurchaseOutp()
                            {
                                ProductID = cur1.ProductID,
                                ROQ = cur1.Price,
                                RUQ = cur1.Quantity,
                                RPQ = cur1.GlobalQuantity,
                                RV = cur1.Price * cur1.Quantity * cur1.GlobalQuantity,
                                BMPProduct = minp,
                                WAP = wap
                            };
                        } while (en1.MoveNext() && (cur1 = en1.Current).ProductID == ID);
    
                        if (cur1.ProductID == ID) { yield break; }
    
                    } while (true);
                }
            }
    
            public override List<ProductPurchaseOutp> ComputeMatches()
            {
                return matched().ToList();
            }
        }
    
        public class JoinTestClassHashMe : TestClass
        {
            public override List<ProductPurchaseOutp> ComputeMatches()
            {
                var l2 = ListTwo
                    .GroupBy(l => l.ProductID)
                    .ToDictionary(p => p.Key);
    
                return ListOne
                    .Select(listOne =>
                {
                    decimal wap = 0;
                    ProductPurchase minp = null;
    
                    if (l2.TryGetValue(listOne.ProductID, out var matches))
                    {
                        long qsum = 0;
                        decimal psum = 0;
                        decimal min = decimal.MaxValue;
                        foreach (var m in matches)
                        {
                            long quantity = (long)m.Quantity * m.GlobalQuantity;
                            var price = m.Price;
                            qsum += quantity;
                            psum += quantity * price;
                            if (price < min)
                            {
                                minp = m;
                                min = price;
                            }
                        }
    
                        if (qsum != 0)
                        {
                            wap = psum / qsum;
                        }
                    }
    
    
                    return new ProductPurchaseOutp
                    {
                        ProductID = listOne.ProductID,
                        ROQ = listOne.Price,
                        RUQ = listOne.Quantity,
                        RPQ = listOne.GlobalQuantity,
                        RV = listOne.Price * listOne.Quantity * listOne.GlobalQuantity,
                        BMPProduct = minp,
                        WAP = wap
                    };
    
                })
                .Where(p => p != null)
                .ToList();
            }
        }
    
    
    
    
    
    
        public static class Extensions
        {
            public static bool IsEmpty<T>(this IEnumerable<T> source)
            {
                return !source.Any();
            }
        }
    
    
        public class ProductPurchase
        {
            public int ProductID
            {
                get;
                set;
            }
            public decimal Price
            {
                get;
                set;
            }
            public int Quantity
            {
                get;
                set;
            }
            public int GlobalQuantity
            {
                get;
                set;
            }
        }
    
        public class ProductPurchaseOutp
        {
            public int ProductID
            {
                get;
                set;
            }
            public decimal ROQ
            {
                get;
                set;
            }
            public int RUQ
            {
                get;
                set;
            }
            public int RPQ
            {
                get;
                set;
            }
    
            public decimal RV
            {
                get;
                set;
            }
    
            public ProductPurchase BMPProduct { get; set; }
            public decimal WAP { get; set; }
    
            public bool IsEqualTo(ProductPurchaseOutp b)
            {
                return this.ProductID == b.ProductID
                    && this.ROQ == b.ROQ
                    && this.RPQ == b.RPQ
                    && this.RUQ == b.RUQ
                    && this.RV == b.RV
                    && this.WAP == b.WAP
                    && (this.BMPProduct == null && b.BMPProduct == null ||
                       this.BMPProduct != null && b.BMPProduct != null
                    && this.BMPProduct.GlobalQuantity == b.BMPProduct.GlobalQuantity
                    && this.BMPProduct.Price == b.BMPProduct.Price
                    && this.BMPProduct.ProductID == b.BMPProduct.ProductID
                    && this.BMPProduct.Quantity == b.BMPProduct.Quantity);
            }        
        }
