    public void NewExecuteTest()
    {
        // Arrange
        PurchaseOrder purchaseOrder = GetPurchaseOrder();
        // Get a fake PosMessageProcessor that falls back to original behaviour for all calls.
        IPosMessageProcessor fakePosMessageProcessor = A.Fake<PosMessageProcessor>(options => options.CallsBaseMethods());
        // Now fake out the GetOrderForProcessing call so we can test Execute.
        A.CallTo(() => fakePosMessageProcessor.GetOrderForProcessing(A<IPurchaseOrderRepository>.Ignored)).Returns(purchaseOrder);
        // Act
        fakePosMessageProcessor.Execute();
        // Assert
        A.CallTo(() => fakePosMessageProcessor.GetOrderForProcessing(A<IPurchaseOrderRepository>.Ignored)).MustHaveHappened();
    }
