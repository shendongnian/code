    class CommonSectionViewModel
    {
        public string Data { get; set; } // Just Example Data
        public int Count { get; set; }
    }
    class ProductsModel
    {
        public CommonSectionViewModel CommonData { get; set; }
        // Other properties for a products models
    }
    class CompaniesModel
    {
        public CommonSectionViewModel CommonData { get; set; }
        // Other properties for a company model
    }
