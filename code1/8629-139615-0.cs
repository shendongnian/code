    class VipCustomer : Customer
    {
      .....
    }
    static void Main()
    {
       Customer c = new VipCustomer();
       c.GetType(); // returns typeof(VipCustomer)
    }
