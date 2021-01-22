    using System.Linq;
    static class Program
    {
        static void Main()
        {
            var users = new User[0]; // intentionally 0; only exists to prove compiles
            var orders = new Order[0];
    
            var query = users.Join(orders, user => user.UserId, order => order.OrderId, (user,order) => new UserOrderTuple(user,order))
                .Where(tuple => tuple.State != 42).OrderByDescending(tuple => tuple.Order.OrderId)
                .Select(tuple => new ResultTuple { Comment = tuple.Comment });
        }
    }
    
    class ResultTuple
    {
        public string Comment { get; set; }
    }
    class UserOrderTuple
    {
        public UserOrderTuple(User user, Order order)
        {
            User = user;
            Order = order;
            Comment = "some magic that gets your comment and other let";
            State = 124;
        }
        public string Comment { get; private set; }
        public int State { get; private set; }
        public User User { get; private set; }
        public Order Order { get; private set; }
    }
    class User
    {
        public int UserId { get; set; }
    }
    class Order
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }
