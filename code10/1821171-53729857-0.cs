    class OrderItem
    {
        public int OrderId;
        public int Number;
        public DateTime Date;
        public int ItemId;
        public string ItemName;
        public string ItemDesc;
        public string Address1Id;
        public string Address1Zip;
        public string Address1City;
        public string Address2Id;
        public string Address2Zip1;
        public string Address2City;
    }
    class Item
    {
        public int ItemID;
        public string ItemName;
        public string ItemDesc;
    }
    class Address
    {
        public string AddressId;
        public string AddressZip;
        public string AddressCity;
    }
    class Order
    {
        public int OrderId;
        public int Number;
        public DateTime Date;
        public Address Address1;
        public Address Address2;
        public List<Item> Items;
    }
    static void Main(string[] args)
    {
        List<OrderItem> orderItems = new List<OrderItem>
        {
            new OrderItem()
            {
                    OrderId = 1, Number=1, Date = DateTime.Parse("2018-12-11"),
                    ItemId = 123, ItemName = "Name 123", ItemDesc = "Item 123",
                    Address1Id = "1", Address1City = "New York", Address1Zip = "10001",
                    Address2Id = "2", Address2City = "Boston", Address2Zip1 = "02101"
            }
        };
    
        var query = orderItems.GroupBy(o => new
        {
            o.OrderId,
            o.Number,
            o.Date,
            o.Address1City,
            o.Address1Id,
            o.Address1Zip,
            o.Address2City,
            o.Address2Id,
            o.Address2Zip1
        },
        (group, orders) => new Order
        {
            OrderId = group.OrderId,
            Number = group.Number,
            Date = group.Date,
            Address1 = new Address() { AddressCity = group.Address1City, AddressId = group.Address1Id, AddressZip = group.Address1Zip },
            Address2 = new Address() { AddressCity = group.Address2City, AddressId = group.Address2Id, AddressZip = group.Address2Zip1 },
            Items = (from o in orders select new Item() { ItemID = o.ItemId, ItemDesc = o.ItemDesc, ItemName = o.ItemName  }).ToList()
        });
        //do something with query
        return 0;
    }
