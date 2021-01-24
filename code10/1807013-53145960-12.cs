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
                Quantity = 20,
                Sku = "B"
            },
            new OrderLine
            {
                Quantity = 10,
                Sku = "A"
            }
        }
    };
    var order4 = new Order
    {
        OrderNumber = 4,
        Lines = new List<OrderLine>
        {
            new OrderLine
            {
                Quantity = 20,
                Sku = "B"
            },
            new OrderLine
            {
                Quantity = 10,
                Sku = "A"
            }
        }
    };
    var order5 = new Order
    {
        OrderNumber = 5,
        Lines = new List<OrderLine>
        {
            new OrderLine
            {
                Quantity = 30,
                Sku = "C"
            }
        }
    };
    var order6 = new Order
    {
        OrderNumber = 6,
        Lines = new List<OrderLine>
        {
            new OrderLine
            {
                Quantity = 40,
                Sku = "C"
            }
        }
    };
    var order7 = new Order
    {
        OrderNumber = 7,
        Lines = new List<OrderLine>
        {
            new OrderLine
            {
                Quantity = 30,
                Sku = "C"
            }
        }
    };
    var orderList = new List<Order>(new[] {order1, order2, order3, order4, order5, order6, order7});
