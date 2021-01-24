        namespace Model
    {
    
        public class Order
        {
            public int Id { get; set; }
    
            public int CustomerId { get; set; }
    
            [ForeignKey( "CustomerId" )]
            public virtual Customer Customer { get; set; }
    
            public virtual List<OrderDetail> Details { get; private set; }
    
            public double Total { get { return Details.Sum( t => t.SubTotal ); } }
    
            public Order()
            {
                this.Details = new List<OrderDetail>();
            }
        }
    
        public class OrderDetail
        {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public virtual Order Order { get; set; }
    
            public int ItemId { get; set; }
    
            [ForeignKey( "ItemId" )]
            public virtual Item Item { get; set; }
    
            public int Quantity { get; set; }
    
            public double SubTotal { get { return this.Item.Price * this.Quantity; } }
        }
    
        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public double Cost { get; set; }
        }
    }
    
    namespace Try
    {
        public class Program
        {
            public static void Main()
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    context.Items.AddOrUpdate( t => t.Name, 
                        new Model.Item() { Name = "MyProduct1", Price= 14.5, Cost=11.5, Description="" } ,
                        new Model.Item() { Name = "MyProduct2", Price = 16.5, Cost = 14.5, Description = "" },
                        new Model.Item() { Name = "MyProduct3", Price = 20.5, Cost = 18.5, Description = "" },
                        new Model.Item() { Name = "MyProduct4", Price = 10.5, Cost = 8.5, Description = "" }
                        );
    
                    context.Savechanges();
    
    
                    Model.Order Order= new Model.Order() { CustomerId=3};
    
                    Order.Details.AddRange( new Model.OrderDetail[] {
                    new Model.OrderDetail {  ItemId= 1, Quantity=2},
                    new Model.OrderDetail {  ItemId= 2, Quantity=1},
                    new Model.OrderDetail {  ItemId= 3, Quantity=5},
                    new Model.OrderDetail {  ItemId= 4, Quantity=6}
                    } );
    
                    Console.WriteLine( "Total: {0} for {1} Items", Order.Total, Order.Details.Count );
                    Console.ReadLine();
                }               
    
            }
        }
    }
