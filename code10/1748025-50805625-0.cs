    public class SOLineExt : PXCacheExtension<PX.Objects.SO.SOLine>
    {
        #region UsrItemStatus
        public abstract class usrItemStatus : PX.Data.IBqlField
        {
        }
        protected string _UsrItemStatus;
        [PXString()]
        [PXUIField(DisplayName = "Status", IsReadOnly = true)]
        //Sub-Select or Sub Query - required to get value for Saved SO Lines
        [PXDBScalar(typeof(Search<InventoryItem.itemStatus, 
                 Where<InventoryItem.inventoryID, Equal<SOLine.inventoryID>>>))]
        //StringList Attribute so that you don’t need to convert value to display text
        [InventoryItemStatus.List]
        //Defaulted when inserting new SO Line
        [PXDefault(typeof(Search<InventoryItem.itemStatus, 
                 Where<InventoryItem.inventoryID, Equal<Current<SOLine.inventoryID>>>>),
                   PersistingCheck = PXPersistingCheck.Nothing)]
        //Triggering default assignment upon changing Inventory ID in SO Line 
        [PXFormula(typeof(Default<SOLine.inventoryID>))]
        public virtual string UsrItemStatus
        {
            get
            {
                return this._UsrItemStatus;
            }
            set
            {
                this._UsrItemStatus = value;
            }
        }
        #endregion
    }
