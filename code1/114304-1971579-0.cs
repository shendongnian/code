    public static class LineItemEntityExtensions
    {
      public static decimal CalculateTotal(this LineItemEntity li)
      {
        return li.Quantity * li.Price;
      }
    }
    public static class OrderEntityExtensions
    {
      public static decimal CalculateOrderTotal(this OrderEntity order)
      {
        decimal orderTotal = 0;
        foreach (LineItemEntity li in order.LineItems)
          orderTotal += li.CalculateTotal();
        return orderTotal;
      }
    }
    public class SomewhereElse
    {
      public void DoSomething(OrderEntity order)
      {
        decimal total = order.CalculateOrderTotal();
        ...
      }
    }
