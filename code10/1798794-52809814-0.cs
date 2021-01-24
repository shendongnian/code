    public class BPCategory 
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string PercentShare { get; set; }
        public string BPCategory1 { get; set; }
        public string DealerCode  { get; set; }
        public string Status { get; set; }
        [NavigationAttribute]
        public List<Product> Product { get; set; }
    }
    foreach (PropertyInfo property in values.GetProperties())
    {
        var isNavProp = property.GetCustomAttributes(typeof(NavigationAttribute), false).Count() == 1;
        if (isNavProp)
                expression.ForMember(property.Name, opt => opt.Ignore());
    }
