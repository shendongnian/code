    public class Apartment
        {
            [Key]
            public int ID { get; set; }
            public string Title { get; set; }
            public int NbofRooms { get; set; }
            public int Price { get; set; }
            public string Address { get; set; }
            public int BuyerId { get; set; } //Make it nullable if an aparment may not have a buyer at some point
            
            public Buyer Buyer { get; set; }
        }
