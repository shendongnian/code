        static void Main(string[] args)
        {
            List<ProductDM> productDMList = new List<ProductDM>()
            {
                new ProductDM()
                {
                    ProductID = 1,
                    CabinetList = new List<InventoryDM>()
                    {
                        new InventoryDM()
                        {
                            Min = 1,
                            Max = 12
                        }
                    }
                },
                new ProductDM()
                {
                    ProductID = 1,
                    CabinetList = new List<InventoryDM>()
                    {
                        new InventoryDM()
                        {
                            Min = 16,
                            Max = 100
                        }
                    }
                },
            };
            Dictionary<int, ProductDM> dict = new Dictionary<int, ProductDM>();
            foreach(ProductDM product in productDMList)
            {
                if(!dict.ContainsKey(product.ProductID))
                {
                    dict.Add(product.ProductID, product);
                }
                else
                {
                    dict[product.ProductID].CabinetList.AddRange(product.CabinetList.ToArray());
                }
            }
            Console.ReadKey(true);
        }
