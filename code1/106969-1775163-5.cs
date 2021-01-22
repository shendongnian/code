    class Order : Entity
    {
        public Order()
        {
            OrderItems = new MyCollection2<OrderItem>(
                //Validation action
                item => item.Name != null && item.Name.Length < 20,
                //Add action
                item => item.Parent = this,
                //Remove action
                item => item.Parent = null
            );
        }
        ...
    }
