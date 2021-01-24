      public ProductModel()
        {
            Product_stores = new List<int>();
            Product_related = new List<int>();
            Product_categories = new List<int>() { 1, 2 , 3 , 4};
        }
     var jsonStr = JsonConvert.SerializeObject(new ProductModel() , Formatting.Indented);
            Console.WriteLine(jsonStr);
            Console.ReadLine();
            
