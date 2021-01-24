    public void RemoveItem(int purchaseOrderId, int itemId)
    {
        using(var unitOfWork = this.purchaseOrderRepository.BeginUnitOfWork())
        {
            var purchaseOrder = this.purchaseOrderRepository.LoadById(purchaseOrderId);
    
            purchaseOrder.RemoveItem(itemId);
    
            this.purchaseOrderRepository.Save(purchaseOrder); 
            unitOfWork.Commit();
        }
    }
