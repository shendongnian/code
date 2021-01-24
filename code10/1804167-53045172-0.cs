    // Create the sales order.
    SalesOrder order = new SalesOrder()
    {
    	Name = "Faux Order",
    	DateFulfilled = new DateTime(2010, 8, 1),
    	PriceLevelId = new EntityReference(PriceLevel.EntityLogicalName,
    		_priceListId),
    	CustomerId = new EntityReference(Account.EntityLogicalName,
    		_accountId),
    	FreightAmount = new Money(20.0M)
    };
    _orderId = _serviceProxy.Create(order);
    order.Id = _orderId;
    
    // Add the product to the order with the price overriden with a
    // negative value.
    SalesOrderDetail orderDetail = new SalesOrderDetail()
    {
    	ProductId = new EntityReference(Product.EntityLogicalName, 
    		_product1Id),
    	Quantity = 4,
    	SalesOrderId = order.ToEntityReference(),
    	IsPriceOverridden = true,
    	PricePerUnit = new Money(-40.0M),
    	UoMId = new EntityReference(UoM.EntityLogicalName, 
    		_defaultUnitId)
    };
    _orderDetailId = _serviceProxy.Create(orderDetail);
