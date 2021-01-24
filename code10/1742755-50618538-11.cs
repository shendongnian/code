    public class PurchaseOrderRepository
    {
        // ...
        public void Save(PurchaseOrder toSave)
        {
            var queryBuilder = new StringBuilder();
            foreach(var item in toSave.Items)
            {
               // Insert, update or remove the item
               // Build up your db command here for example:
               queryBuilder.AppendLine($"INSERT INTO [PurchaseOrder_Item] VALUES ([{toSave.PurchaseOrderId}], [{item.ItemId}])");
               
            }
        }
        // ...
    }
