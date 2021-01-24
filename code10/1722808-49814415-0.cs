    class Program
    {
        static void Main(string[] args)
        {
            var data = new TVSystemViewData();
            var listOfDisplayNames = data.GetAttributesNames();
        }
    }
    internal class TVSystemViewData
    {
        [Display(Name = "XXXXX", Description = "")]
        public String BoxType { get; set; }
        [Display(Name = "BoxVendor", Description = "")]
        public String BoxVendor { get; set; }
        [Display(Name = "ClientId", Description = "")]
        public String ClientId { get; set; }
        [Display(Name = "HostName", Description = "")]
        public String HostName { get; set; }
        [Display(Name = "OSVersion", Description = "")]
        public String OSVersion { get; set; }
        [Display(Name = "SerialNumber", Description = "")]
        public String SerialNumber { get; set; }
        internal List<string> GetAttributesNames()
        {
            return typeof(TVSystemViewData)
                .GetProperties()
                .Select(x => ((DisplayAttribute) x.GetCustomAttribute(typeof(DisplayAttribute), true)).Name)
                .ToList();
        }
    }
