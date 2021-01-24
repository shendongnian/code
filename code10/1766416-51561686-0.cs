    public class NewWheel {
        public int WheelId { get; set; }
        [FromRoute]
        public int CarId { get; set; }
        public string BrandName { get; set; }
    }
