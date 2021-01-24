    public class InventoryItemDemoPXExt : PXCacheExtension<InventoryItem>
    {
        public abstract class itemAttributes : IBqlField { }
        [PXAddAtttributeColumns(new[] { "COLOR", "CONFIGURAB", "PIXELSIZE", "WIDEANGLE" },
                                        typeof(InventoryItem.itemClassID),
                                        typeof(InventoryItem.noteID))]
        public virtual string[] ItemAttributes { get; set; }
    }
