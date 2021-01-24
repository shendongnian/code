       public class DisputeUpdateStatusModel
        {
            public string DisputeId { get; set; }
            public string DisputeStatusId { get; set; }
        }
        public class DisputeController : Controller
        {
          
            [HttpPost]
            public virtual ActionResult UpdateDisputeStatus(DisputeUpdateStatusModel model)
            {
                return new ContentResult() { Content = "OK" };
            }
        }
