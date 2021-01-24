    public class XX : IX
    {
        public IX SingleItem { get; set; }
        public List<IX> ListOfItems { get; set; }
        public XX(IX item)
        {
            SingleItem = item;
        }
        public XX(List<IX> items)
        {
            ListOfItems = items;
        }
    }
