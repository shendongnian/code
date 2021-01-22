    interface IOrderDetails
    {
        void PlaceOrder();
    }
    //Sometime later you extend with:
    interface IOrderDetails2 : IOrderDetails
    {
        void PlaceOrder(IUser user);
    }
    //Implementation
    class Order : IOrderDetails, IOrderDetails2
    {
        static readonly IUser AnonUser;
        void IOrderDetails.PlaceOrder()
        { OnPlaceOrder(AnonUser); }
        void IOrderDetails2.PlaceOrder(IUser user)
        { OnPlaceOrder(user); }
        protected virtual void OnPlaceOrder(IUser user)
        { 
        }
    }
