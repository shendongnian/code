    public partial class PurchaseOrder 
    {
        partial void OnLoaded()
        {
            LineItems = FunctionToCall_sp_getPurchaseOrderLineItems_AndBuildSet();
        }
    }
