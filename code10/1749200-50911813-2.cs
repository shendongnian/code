    using System.ComponentModel.DataAnnotations;
    public class Product
    {
        [Display(Name = "Code", Description = "Unique code of the product")]
        public int Id { get; set; }
        [Display(Name = "Product Name", Description = "Name of the product")]
        public string Name { get; set; }
        [Display(Name = "Unit Price", Description = "Unit price of the product")]
        [DisplayFormat(DataFormatString = "C2")]
        public double Price { get; set; }
    }
