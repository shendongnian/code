    public class InventoryController : Controller
    {
        [Route(whatever/{firstItem})]
        public ActionResult ViewStockNext(int firstItem)
        {
            int yourNewVariable = firstItem;
            // ...
        }
    }
