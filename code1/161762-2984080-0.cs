    public static class MyAssertions
    {
        public static void AreOrdersEqual(Order a, Order b)
        {
            if (!OrdersAreEqual) // your comparison logic here
               Assert.Fail("Orders arent equal");           
        }
    }
