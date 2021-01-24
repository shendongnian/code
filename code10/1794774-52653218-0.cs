    SalesOrder soToBeFound = new SalesOrder
    {
        ReturnBehavior = ReturnBehavior.All,
        OrderType = new StringSearch { Value = orderType },
        CustomerOrder = new StringSearch { Value = customerOrder },
        Details = new SalesOrderDetail[]
        {
            new SalesOrderDetail { ReturnBehavior = ReturnBehavior.All }
        }
    };
