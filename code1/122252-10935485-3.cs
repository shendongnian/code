    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace LinqLookupSpike
    {
        class Program
        {
            static void Main(String[] args)
            {
                // init 
                var orderList = new List<Order>();
                orderList.Add(new Order(1, 1, 2010, true));//(orderId, customerId, year, isPayed)
                orderList.Add(new Order(2, 2, 2010, true));
                orderList.Add(new Order(3, 1, 2010, true));
                orderList.Add(new Order(4, 2, 2011, true));
                orderList.Add(new Order(5, 2, 2011, false));
                orderList.Add(new Order(6, 1, 2011, true));
                orderList.Add(new Order(7, 3, 2012, false));
                // lookup Order by its id (1:1, so usual dictionary is ok)
                Dictionary<Int32, Order> orders = orderList.ToDictionary(o => o.OrderId, o => o);
                // lookup Order by customer (1:n) 
                // would need something like Dictionary<Int32, IEnumerable<Order>> orderIdByCustomer
                ILookup<Int32, Order> byCustomerId = orderList.ToLookup(o => o.CustomerId);
                foreach (var customerOrders in byCustomerId)
                {
                    Console.WriteLine("Customer {0} ordered:", customerOrders.Key);
                    foreach (var order in customerOrders)
                    {
                        Console.WriteLine("    Order {0} is payed: {1}", order.OrderId, order.IsPayed);
                    }
                }
                // the same using old fashioned Dictionary
                Dictionary<Int32, List<Order>> orderIdByCustomer;
                orderIdByCustomer = byCustomerId.ToDictionary(g => g.Key, g => g.ToList());
                foreach (var customerOrders in orderIdByCustomer)
                {
                    Console.WriteLine("Customer {0} ordered:", customerOrders.Key);
                    foreach (var order in customerOrders.Value)
                    {
                        Console.WriteLine("    Order {0} is payed: {1}", order.OrderId, order.IsPayed);
                    }
                }
                // lookup Order by payment status (1:m) 
                // would need something like Dictionary<Boolean, IEnumerable<Order>> orderIdByIsPayed
                ILookup<Boolean, Order> byPayment = orderList.ToLookup(o => o.IsPayed);
                IEnumerable<Order> payedOrders = byPayment[false];
                foreach (var payedOrder in payedOrders)
                {
                    Console.WriteLine("Order {0} from Customer {1} is not payed.", payedOrder.OrderId, payedOrder.CustomerId);
                }
            }
            class Order
            {
                // key properties
                public Int32 OrderId { get; private set; }
                public Int32 CustomerId { get; private set; }
                public Int32 Year { get; private set; }
                public Boolean IsPayed { get; private set; }
                // additional properties
                // private List<OrderItem> _items;
                public Order(Int32 orderId, Int32 customerId, Int32 year, Boolean isPayed)
                {
                    OrderId = orderId;
                    CustomerId = customerId;
                    Year = year;
                    IsPayed = isPayed;
                }
            }
        }
    }
    
