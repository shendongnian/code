                using O = TestingDynasql.OrderTable;
              ...
                DBQuery.Select()
                .Field(O.CustomerID)
                .Count(O.OrderID)
                .From(O.Orders)
                .GroupBy(O.CustomerID)
                .OrderBy(O.CustomerID)
                .WhereField(O.OrderDate, Compare.GreaterThan, DBConst.DateTime(ordersAfter))             
