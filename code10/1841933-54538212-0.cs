    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }
    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
    }
    public class RootObject
    {
        public List<object> html_attributions { get; set; }
        public Result result { get; set; }
    }
