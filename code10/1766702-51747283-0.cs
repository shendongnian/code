    using PX.Api; 
    using PX.Api.ContractBased; 
    using PX.Api.ContractBased.Models; 
    using PX.Data;
    using PX.Objects.PO;
    using PX.Objects.IN;
    using System;
    using System.Linq;
    using PX.Objects.CM;
    using PX.Objects.CS;
    
    namespace AcuStock
    {
      [PXVersion("5.30.001", "AcuStock")]  
      [PXVersion("6.00.001", "AcuStock")]  
      [PXVersion("17.200.001", "AcuStock")]  
      public class AcuStockEndpointImpl : PX.Objects.DefaultEndpointImpl
      {
        
        [FieldsProcessed(new[] { "POLineNbr", "POOrderType", "POOrderNbr", "OrigLineNbr", "OrigRefNbr" })]
        protected new void PurchaseReceiptDetail_Insert(PXGraph graph, EntityImpl entity, EntityImpl targetEntity){
      
            var lineNbr = targetEntity.Fields.SingleOrDefault(f => f.Name == "OrigLineNbr") as EntityValueField;
            var refNbr = targetEntity.Fields.SingleOrDefault(f => f.Name == "OrigRefNbr") as EntityValueField;
            var receiptQty = targetEntity.Fields.SingleOrDefault(f => f.Name == "ReceiptQty") as EntityValueField;
            var location = targetEntity.Fields.SingleOrDefault(f => f.Name == "Location") as EntityValueField;
            var inventoryID = targetEntity.Fields.SingleOrDefault(f => f.Name == "InventoryID") as EntityValueField;
    
            bool insertViaAddTR = lineNbr != null && refNbr != null;
    
            var receiptEntry = (POReceiptEntry) graph;
            
            if (insertViaAddTR){
    
                receiptEntry.addReceipt.Cache.Remove(receiptEntry.addReceipt.Current);
                receiptEntry.addReceipt.Cache.Insert(new POReceiptEntry.POReceiptLineS());
    
                var filter = receiptEntry.addReceipt.Current;
    
                receiptEntry.addReceipt.Cache.SetValueExt(filter, "OrigRefNbr", refNbr.Value);
                receiptEntry.addReceipt.Cache.SetValueExt(filter, "OrigLineNbr", lineNbr.Value);
                receiptEntry.addReceipt.Cache.SetValueExt(filter, "InventoryID", inventoryID.Value);
                receiptEntry.addReceipt.Cache.SetValueExt(filter, "ReceiptQty", receiptQty.Value);
                if (location != null)
                    receiptEntry.addReceipt.Cache.SetValueExt(filter, "LocationID", location.Value);
                receiptEntry.addReceipt.Update(filter);
    
                var lines = receiptEntry.addReceipt.Select().Select(r => r.GetItem<POReceiptEntry.POReceiptLineS>());
                var line = lines.FirstOrDefault(o => o.OrigLineNbr == int.Parse(lineNbr.Value));
    
                if (line == null){
                    throw new PXException(PX.Objects.PO.Messages.PurchaseOrderLineNotFound);
                }
    
                receiptEntry.addPOReceiptLine2.Press();
    
            } else {
                base.PurchaseReceiptDetail_Insert(graph, entity, targetEntity);
            }
    
            var allocations = (targetEntity.Fields.SingleOrDefault(f => string.Equals(f.Name, "Allocations")) as EntityListField).Value ?? new EntityImpl[0];
    
            if (allocations.Any(a => a.Fields != null && a.Fields.Length > 0)){
                // Remove automatically added allocation
                if (receiptEntry.splits.Current != null){
                    receiptEntry.splits.Delete(receiptEntry.splits.Current);
                }
        }
        
        }
    
        [FieldsProcessed(new[] { "OrigLineNbr", "OrigRefNbr", "Quantity", "Location" })]
        protected void ReceiptDetails_Insert(PXGraph graph, EntityImpl entity, EntityImpl targetEntity) {
    
            var lineNbr = targetEntity.Fields.SingleOrDefault(f => f.Name == "OrigLineNbr") as EntityValueField;
            var receiptQty = targetEntity.Fields.SingleOrDefault(f => f.Name == "Quantity") as EntityValueField;
            var location = targetEntity.Fields.SingleOrDefault(f => f.Name == "Location") as EntityValueField;
    
            var allocations = (targetEntity.Fields.SingleOrDefault(f => string.Equals(f.Name, "Allocations")) as EntityListField).Value ?? new EntityImpl[0];
            var hasAllocations = allocations.Any(a => a.Fields != null && a.Fields.Length > 0);
    
            var receiptEntry = (INReceiptEntry) graph;
    
            string transferNbr = receiptEntry.receipt.Current.TransferNbr;
                
            var detailsCache = receiptEntry.transactions.Cache;
    
            if (lineNbr == null || transferNbr == null){
    
                detailsCache.Current = detailsCache.Insert();
                return;
            }
    
            INTran newtran = null;
            decimal newtranqty = Decimal.Parse(receiptQty.Value);
            decimal newtrancost = 0m;
            receiptEntry.ParseSubItemSegKeys();
    
            using (new PXReadBranchRestrictedScope())
            {
                foreach (PXResult<INTransitLine, INLocationStatus2, INTransitLineLotSerialStatus, INSite, InventoryItem, INTran> res in
                    PXSelectJoin<INTransitLine,
                    InnerJoin<INLocationStatus2, On<INLocationStatus2.locationID, Equal<INTransitLine.costSiteID>>,
                    LeftJoin<INTransitLineLotSerialStatus,
                            On<INTransitLine.transferNbr, Equal<INTransitLineLotSerialStatus.transferNbr>,
                            And<INTransitLine.transferLineNbr, Equal<INTransitLineLotSerialStatus.transferLineNbr>>>,
                    InnerJoin<INSite, On<INSite.siteID, Equal<INTransitLine.toSiteID>>,
                    InnerJoin<InventoryItem, On<InventoryItem.inventoryID, Equal<INLocationStatus2.inventoryID>>,
                    InnerJoin<INTran,
                        On<INTran.docType, Equal<INDocType.transfer>,
                        And<INTran.refNbr, Equal<INTransitLine.transferNbr>,
                        And<INTran.lineNbr, Equal<INTransitLine.transferLineNbr>,
                        And<INTran.invtMult, Equal<shortMinus1>>>>>>>>>>,
                    Where<INTransitLine.transferNbr, Equal<Required<INTransitLine.transferNbr>>, And<INTransitLine.transferLineNbr, Equal<Required<INTransitLine.transferLineNbr>>>>,
                    OrderBy<Asc<INTransitLine.transferNbr, Asc<INTransitLine.transferLineNbr>>>>
                    .Select(receiptEntry, transferNbr, lineNbr.Value))
                {
                    INTransitLine transitline = res;
                    INLocationStatus2 stat = res;
                    INTransitLineLotSerialStatus lotstat = res;
                    INSite site = res;
                    InventoryItem item = res;
                    INTran tran = res; 
    
                    if (stat.QtyOnHand == 0m || (lotstat != null && lotstat.QtyOnHand == 0m))
                        continue;
    
                    if (newtran == null) { 
    
                        if (!object.Equals(receiptEntry.receipt.Current.BranchID, site.BranchID))
                        {
                            INRegister copy = PXCache<INRegister>.CreateCopy(receiptEntry.receipt.Current);
                            copy.BranchID = site.BranchID;
                            receiptEntry.receipt.Update(copy);
                        }
    
                        newtran = PXCache<INTran>.CreateCopy(tran);
                        newtran.OrigBranchID = newtran.BranchID;
                        newtran.OrigTranType = newtran.TranType;
                        newtran.OrigRefNbr = transitline.TransferNbr;
                        newtran.OrigLineNbr = transitline.TransferLineNbr;
                        newtran.BranchID = site.BranchID;
                        newtran.DocType = receiptEntry.receipt.Current.DocType;
                        newtran.RefNbr = receiptEntry.receipt.Current.RefNbr;
                        newtran.LineNbr = (int)PXLineNbrAttribute.NewLineNbr<INTran.lineNbr>(receiptEntry.transactions.Cache, receiptEntry.receipt.Current);
                        newtran.InvtMult = (short)1;
                        newtran.SiteID = transitline.ToSiteID;
                        newtran.LocationID = transitline.ToLocationID;
                        newtran.ToSiteID = null;
                        newtran.ToLocationID = null;
                        newtran.BaseQty = 0m;
                        newtran.Qty = 0m;
                        newtran.UnitCost = 0m;
                        newtran.Released = false;
                        newtran.InvtAcctID = null;
                        newtran.InvtSubID = null;
                        newtran.ReasonCode = null;
                        newtran.ARDocType = null;
                        newtran.ARRefNbr = null;
                        newtran.ARLineNbr = null;
                        newtran.ProjectID = null;
                        newtran.TaskID = null;
                        newtran.CostCodeID = null;
                        newtran.TranCost = 0m;
    
                        receiptEntry.splits.Current = null;
    
                        newtran = receiptEntry.transactions.Insert(newtran);
    
                        receiptEntry.transactions.Current = newtran;
    
                        if (receiptEntry.splits.Current != null)
                        {
                            receiptEntry.splits.Delete(receiptEntry.splits.Current);
                        }
                    }
    
                    if (hasAllocations){
    
                        newtranqty = 0m;
    
                        foreach (var allocation in allocations) { 
    
                            var newsplitqty = allocation.Fields.SingleOrDefault(f => f.Name == "Quantity") as EntityValueField;
                            var newsplitlocation = allocation.Fields.SingleOrDefault(f => f.Name == "Location") as EntityValueField;
    
                            INTranSplit newsplit = this.addReceiptSplitLine(receiptEntry, stat, lotstat, transitline, newtran, item, Decimal.Parse(newsplitqty.Value), newsplitlocation.Value);
    
                            newtrancost += newsplit.BaseQty.Value * newsplit.UnitCost.Value;
                            newtranqty += newsplit.BaseQty.Value;
                        }
    
                        break;
    
                    } else {
    
                        INTranSplit newsplit = this.addReceiptSplitLine(receiptEntry, stat, lotstat, transitline, tran, item, newtranqty, null);
    
                        newtrancost += newsplit.BaseQty.Value * newsplit.UnitCost.Value;
                        newtranqty += newsplit.BaseQty.Value;
    
                    }
                    
                }
    
                receiptEntry.UpdateTranCostQty(newtran, newtranqty, newtrancost);
    
            }
    
        }
    
        [FieldsProcessed(new[] { "OrigLineNbr" })]
        protected void ReceiptAllocations_Insert(PXGraph graph, EntityImpl entity, EntityImpl targetEntity) {
            // no-op
        }
    
        private INTranSplit addReceiptSplitLine(INReceiptEntry receiptEntry, INLocationStatus2 stat, INTransitLineLotSerialStatus lotstat, INTransitLine transitline, INTran tran, InventoryItem item, Decimal qty, string location){
    
            INTranSplit newsplit;
            decimal newsplitqty;
            if (lotstat.QtyOnHand == null)
            {
                newsplit = new INTranSplit();
                newsplit.InventoryID = stat.InventoryID;
                newsplit.IsStockItem = true;
                newsplit.FromSiteID = transitline.SiteID;
                newsplit.SubItemID = stat.SubItemID;
                newsplit.LotSerialNbr = null;
                newsplitqty = qty;
            }
            else
            {
                newsplit = new INTranSplit();
                newsplit.InventoryID = lotstat.InventoryID;
                newsplit.IsStockItem = true;
                newsplit.FromSiteID = lotstat.FromSiteID;
                newsplit.SubItemID = lotstat.SubItemID;
                newsplit.LotSerialNbr = lotstat.LotSerialNbr;
                newsplitqty = qty;
            }
    
            newsplit.DocType = receiptEntry.receipt.Current.DocType;
            newsplit.RefNbr = receiptEntry.receipt.Current.RefNbr;
            newsplit.LineNbr = tran.LineNbr;
            newsplit.SplitLineNbr = (int)PXLineNbrAttribute.NewLineNbr<INTranSplit.splitLineNbr>(receiptEntry.splits.Cache, receiptEntry.receipt.Current);
    
            newsplit.UnitCost = 0m;
            newsplit.InvtMult = (short)1;
            newsplit.SiteID = transitline.ToSiteID;
            newsplit.PlanID = null;
            newsplit.Released = false;
            newsplit.ProjectID = null;
            newsplit.TaskID = null;
    
            if (location == null) { 
                newsplit.LocationID = lotstat.ToLocationID ?? transitline.ToLocationID;
            } else { 
                receiptEntry.splits.SetValueExt<INTranSplit.locationID>(newsplit, location);
            }
    
            newsplit = receiptEntry.splits.Insert(newsplit);
    
            newsplit.MaxTransferBaseQty = newsplitqty;
            newsplit.BaseQty = newsplitqty;
            newsplit.Qty = newsplit.BaseQty.Value;
    
            receiptEntry.UpdateCostSubItemID(newsplit, item);
    
            receiptEntry.SetCostAttributes(tran, newsplit, item, tran.OrigRefNbr);
            newsplit.UnitCost = PXCurrencyAttribute.BaseRound(receiptEntry, newsplit.UnitCost);
            receiptEntry.splits.Update(newsplit);
    
            return newsplit;
        }
    
      }
    }
