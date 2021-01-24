    public class NewWheel {
        [FromBody]
        public int WheelId { get; set; }
        [FromRoute]
        public int CarId { get; set; }
        [FromBody]
        public string BrandName { get; set; }
    }
