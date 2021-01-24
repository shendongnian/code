    // Consider replacing the default namespace to avoid conflicts
    namespace MyNamespace
    {
      public class InventoryItemMaint_Extension:PXGraphExtension<InventoryItemMaint>
      {
        public PXAction<PX.Objects.IN.InventoryItem> DailyOnixImport;
    
        // '(CommitChanges = true)' is not necessary
        [PXButton]
        [PXUIField(DisplayName = "Daily Onix Import")]
        protected void dailyOnixImport()
        {           
          InventoryItemMaint_Extension invItemMaintExtInstance = Base.GetExtension<InventoryItemMaint_Extension>();
    
          string todaysDate = DateTime.Today.ToString("MM/dd/yyyy");                        
    
          // You need to rethink that 'foreach' logic
          STOnixItem currentOnixItem in PXSelect<STOnixItem,
                                        Where<STOnixItem.addedDate, Equal<Required<STOnixItem.addedDate>>>>.Select(Base, todaysDate);    
                            
          // You can access Base directly, no need to fetch it from the extension
          InventoryItem currentInventoryItem = Base.Item.Current;
    
          // Consider using more null check
          if (currentOnixItem != null && currentInventoryItem != null)
          {
            // Consider using similar names for similar variables
            InventoryItemExt currentInventoryItemExt = currentInventoryItem.GetExtension<InventoryItemExt>();
    
            // Avoid setting key related fields like InventoryCD when updating
            currentInventoryItem.Descr = currentOnixItem.Title;
            currentInventoryItem.ItemClassID = currentOnixItem.ItemClass;
            currentInventoryItem.RecPrice = decimal.Parse(currentOnixItem.MSRP);
            currentInventoryItem.BasePrice = decimal.Parse(currentOnixItem.DefaultPrice);
            currentInventoryItem.BaseItemWeight = decimal.Parse(currentOnixItem.Weight);
            currentInventoryItem.WeightUOM = "POUND";
            currentInventoryItem.ImageUrl = currentOnixItem.ImageLink;
    
            currentInventoryItemExt.UsrFromOnixFile = currentOnixItem.FromFile;
    
            // You fetched the item from the DataView 
            // you can update it in the DataView too.
            Base.Item.Update(currentInventoryItem);
    
            // Is it really needed to save here?
            // This coupled with cache clearing and the loop updating 
            // the same record triggers the error in your question.
            Base.Actions.PressSave();
          }
        }
      }
    }
