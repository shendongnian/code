    public class SOOrderEntryPXDemoExt : PXGraphExtension<SOOrderEntry>
    {
        public override void Initialize()
        {
            Base.Transactions.Join<InnerJoin<InventoryItem, On<InventoryItem.inventoryID, Equal<SOLine.inventoryID>>>>();
        }
        [PX.Api.Export.PXOptimizationBehavior(IgnoreBqlDelegate = true)]
        protected virtual IEnumerable transactions()
        {
            PXSelectBase<SOLine> query =
                new PXSelectJoin<SOLine,
                        LeftJoin<INItemCost, On<INItemCost.inventoryID, Equal<SOLine.inventoryID>>,
                        InnerJoin<InventoryItem, On<InventoryItem.inventoryID, Equal<SOLine.inventoryID>>>>,
                        Where<SOLine.orderType, Equal<Current<SOOrder.orderType>>,
                            And<SOLine.orderNbr, Equal<Current<SOOrder.orderNbr>>>>,
                        OrderBy<Asc<SOLine.orderType, Asc<SOLine.orderNbr, Asc<SOLine.lineNbr>>>>>(Base);
            var ret = new List<PXResult<SOLine, INItemCost, InventoryItem>>();
            int startRow = PXView.StartRow;
            int totalRows = 0;
            foreach (PXResult<SOLine, INItemCost, InventoryItem> record in query.View.Select(
                PXView.Currents, PXView.Parameters, PXView.Searches, PXView.SortColumns,
                PXView.Descendings, PXView.Filters, ref startRow, PXView.MaximumRows, ref totalRows))
            {
                SOLine line = (SOLine)record;
                INItemCost itemCost = (INItemCost)record;
                Base.initemcost.StoreCached(new PXCommandKey(new object[] { line.InventoryID }), new List<object> { itemCost });
                ret.Add(record);
            }
            PXView.StartRow = 0;
            return ret;
        }
    }
