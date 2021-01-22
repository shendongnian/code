    public interface IOrderRepository
    {
        Order SelectSingle(int id);
        void Insert(Order order);
        void Update(Order order);
        void Delete(int id);
        // more, specialized methods can go here if need be
    }
