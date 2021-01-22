    public static void OuterJoinSimpleExample()
    {
        var customers = new List<Customer>() { 
            new Customer {Key = 1, Name = "Gottshall" },
            new Customer {Key = 2, Name = "Valdes" },
            new Customer {Key = 3, Name = "Gauwain" },
            new Customer {Key = 4, Name = "Deane" },
            new Customer {Key = 5, Name = "Zeeman" } 
        };
     
        var orders = new List<Order>() {
            new Order {Key = 1, OrderNumber = "Order 1" },
            new Order {Key = 1, OrderNumber = "Order 2" },
            new Order {Key = 4, OrderNumber = "Order 3" },
            new Order {Key = 4, OrderNumber = "Order 4" },
            new Order {Key = 5, OrderNumber = "Order 5" },
        };
     
        var q = from c in customers
                join o in orders on c.Key equals o.Key into outer
                from o in outer.DefaultIfEmpty()
                select new { 
                    Name = c.Name, 
                    OrderNumber = ((o == null) ? "(no orders)" : o.OrderNumber) 
                };
     
        foreach (var i in q) {
            Console.WriteLine("Customer: {0}  Order Number: {1}", 
                i.Name.PadRight(11, ' '), i.OrderNumber);
        }
     
        Console.ReadLine();
    }
