    public class YourModel
    {
        public int StateProvinceId { get; set; }
        /// ... whatever else you need
    }
    // Then in your view your controller you need to set it and create it
    View(new YourModel() { StateProvinceId = 123 };);
