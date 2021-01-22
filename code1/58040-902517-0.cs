    public void Linq21() {
                List<Customer> customers = GetCustomerList();
 
            var first3WAOrders = (
                from c in customers
                from o in c.Orders
                where c.Region == "WA"
                select new {c.CustomerID, o.OrderID, o.OrderDate} )
                .Take(3);
            
            Console.WriteLine("First 3 orders in WA:");
            foreach (var order in first3WAOrders) {
                ObjectDumper.Write(order);
            }
        }
