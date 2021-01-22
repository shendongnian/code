    public static class ClassB
    {
        //The single instance has to be injected before DoSomethingElse can be used
        public static ClassA ClassA;
        private static void DoSomethingElse(int orderID)
        {
            List<Order> orderList = ClassA.GetOrders(orderID);
            //...rest of code
        }
    }   
