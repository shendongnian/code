    // unchanged:
    interface IOrder {...}
    interface IOnlineOrder : IOrder {...}
    interface IPhoneOrder : IOrder {...}
    interface ICustomer {...}
    // similar to IEnumerator<T> and IEnumerator
    interface IOnlineCustomer : ICustomer
    {
         new List<IOnlineOrder> Orders { get; set; }
    }
    interface IPhoneCustomer : ICustomer
    {
         new List<IPhoneOrder> Orders { get; set; }
    } 
