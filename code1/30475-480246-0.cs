    [TestMethod]
    public void Purchase_Order_Collection_Has_Errors_Is_True_If_Any_Purchase_Order_Has_Is_Valid_False()
    {    
        var mockFirstPurchaseOrder = new Mock<IPurchaseOrder>();
        var mockSecondPurchaseOrder = new Mock<IPurchaseOrder>();
    
        mockFirstPurchaseOrder.Expect(p => p.IsValid).Returns(false).AtMostOnce();
        mockSecondPurchaseOrder.Expect(p => p.IsValid).Returns(true).AtMostOnce();
    
        List<IPurchaseOrder> purchaseOrders = new List<IPurchaseOrder>();
        purchaseOrders.Add(mockFirstPurchaseOrder.Object);
        purchaseOrders.Add(mockSecondPurchaseOrder.Object);
    
        PurchaseOrderCollection collection = new PurchaseOrderCollection(orders);
    
        Assert.IsTrue(collection.HasErrors);
    }
