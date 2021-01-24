    public string ClassName { get {return "SubCategory";} }
    
    [Remote("IsSubCategoryExist", "Products", AdditionalFields = "ID, ClassName",
            ErrorMessage = "Product name already exists")]
    public string Name { get; set; }
