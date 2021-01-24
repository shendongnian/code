    using System;
    using System.ComponentModel;
    public class Product
    {
        [DisplayName("Code")]
        [Description("Unique code of the product")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        [Description("Name of the product")]
        public string Name { get; set; }
        [DisplayName("Unit Price")]
        [Description("Unit price of the product")]
        [DisplayFormat("C2")]
        public double Price { get; set; }
    }
