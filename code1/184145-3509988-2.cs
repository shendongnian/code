    var warehouseItems = 
        from item in DataTableContainingWarehouseItems.AsEnumerable()
        select
        new
        {
            InventoryName = item.Field<string>("Name"),
            InventoryValue = item.Field<int>("Value"),
            InventoryPrice = item.Field<decimal>("Price"),
            StockOnHandValue = Convert.ToDecimal(item.Field<int>("Value") * item.Field<decimal>("Price"))
        };
