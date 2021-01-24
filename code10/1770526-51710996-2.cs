    public class PizzaViewModel
    {
        public int id { get; set; }
    
        public string Flavour { get; set; }
        public DateTime Date { get; set; }
        public string Size { get; set; }
        public IEnumerable<SelectListItem> Deliverymen { get; set; }
        public int SelectedDeliveryMan { get; set; }
    }
