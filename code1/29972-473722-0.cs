    public void NameOfTest()
    {
        PurchaseOrder_Accessor order = new PurchaseOrder_Accessor();
        order.NewNumber = "123456";
        order.NewLine = "001";
        Assert.IsTrue(order.IsValid);
    }
