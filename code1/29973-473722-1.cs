    public void NameOfTest()
    {
        PurchaseOrder order = new PurchaseOrder()
        PurchaseOrder_Accessor accessor =
                    new PurchaseOrder_Accessor( new PrivateObject(order) );
        accessor.NewNumber = "123456";
        accessor.NewLine = "001";
        Assert.IsTrue(order.IsValid);
    }
