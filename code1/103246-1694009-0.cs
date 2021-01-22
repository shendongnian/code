    public static class YourClassRules
    {
        public List<SomeSortOfValidationItem> Validate(YourClass obj)
        {
            var results = new List<SomeSortOfValidationItem>()
    
            if (obj.YourProperty.Length >= 200)
            {
               results.Add(new SormSortOfValidationItem("YourProperty", "Length must be less than...");
            }
            //etc.
        }
    
    }
