    public class OrdersController : Controller
    {
        public ActionResult UpdateQty(int id)
        {
            return Json(yourLibrary.getQuantities(id));
        }
    }
