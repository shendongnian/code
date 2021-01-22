        public void OutputProductsToConsole(List<IProduct> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].Name + ": " + products[i].Price);
            }
        }
