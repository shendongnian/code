    class Product
    {
         public int ProductId {get; set;}
         public string Name {get; set;}
         public DateTime IntroductionDate {get; set;}
         ...
         // every Product has zero or more features
         // many-to-many using a junction table
    }
    class Feature
    {
        public int Id {get; set;}
        public string Description {get; set;}
        ...
        // every feature is had by zero or more products
        // many-to-many using a junction table
    }
