                public class OrderTable {
                    public const string Orders = "Orders";
                    public const string CustomerID = "CustomerID";
                    public const string OrderID = "OrderID";
                    public const string OrderDate = "OrderDate";
                }
                ...
                DBQuery.Select()
                .Field(OrderTable.CustomerID)
                .Count(OrderTable.OrderID)
                .From(OrderTable.Orders)
                .GroupBy(OrderTable.CustomerID)
                .OrderBy(OrderTable.CustomerID)
                .WhereField(OrderTable.OrderDate, Compare.GreaterThan, DBConst.DateTime(ordersAfter))
