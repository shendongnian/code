    class MyBusinessObject {
        [Required(ErrorMessage="Must enter customer")]
        public string Customer { get; set; }
        [Range(10,99, ErrorMessage="Price must be between 10 and 99")]
        public decimal Price { get; set; }
        // I have also created some custom attributes, e.g. validate paths
        [File(FileValidation.IsDirectory, ErrorMessage = "Must enter an importfolder")]
        public string ImportFolder { get; set; }
        public string this[string columnName] {
            return InputValidation<MyBusinessObject>.Validate(this, columnName);
        }
        public ICollection<string> AllErrors() {
            return InputValidation<MyBusinessObject>.Validate(this);
        }
    }
    
