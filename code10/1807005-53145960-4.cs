    var order1 = new Order
    {
        OrderNumber = 1,
        Lines = new List<OrderLine>
        {
            new OrderLine
            {
                Quantity = 10,
                Sku = "A"
            },
            new OrderLine
            {
                Quantity = 20,
                Sku = "B"
            }
        }
    };
    var order2 = new Order
    {
        OrderNumber = 2,
        Lines = new List<OrderLine>
        {
            new OrderLine
            {
                Quantity = 10,
                Sku = "A"
            }
        }
    };
    var order3 = new Order
    {
        OrderNumber = 3,
        Lines = new List<OrderLine>
        {
            new OrderLine
            {
                Quantity = 10,
                Sku = "A"
            },
            new OrderLine
            {
                Quantity = 20,
                Sku = "B"
            }
        }
    };
    var orderList = new List<Order>(new []{ order1, order2, order3 });
