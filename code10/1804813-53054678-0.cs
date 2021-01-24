    [Test]
    public void StockItem_Should_Cancel_When_PurchaseOrder_Cancelled() {
        //Arrange
        var item = new StockItem();
        var purchaseOrder = new PurchaseOrder() {
            StockItems = new List<StockItem> { 
                item
            }
        };
        //Act
        purchaseOrder.Cancel();
        //Assert
        item.Status.Should().Be(StockItemStatus.Cancelled);
    }
