    public class Bookings
    {
        public string id { get; set; }
        public int code { get; set; }
        public DateTime timeFrom { get; set; }
        public DateTime timeTo { get; set; }
        public Class2 room { get; set; }
    }
    public class Class2
    {
        public string name { get; set; }
        public string id { get; set; }
        public int seats { get; set; }
        public Uri ImageUrl => new Uri($"https://api.rumsbokning.nu/api/companies/aab96aa1-d8ca-4f74-8e35-ded190c38dd4/rooms/{id}/image", UriKind.Absolute);
    }
