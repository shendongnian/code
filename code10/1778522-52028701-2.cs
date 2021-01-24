    public class TotalItemValue:IEntity
    {
          ...
          public int QuoteId{ get; set; }
          ...
    }
    [HttpPost]
        public ActionResult CreateMiscellaneousItem(TotalItemValue model)
        {
           ...
           _expressionTotalService.SaveMiscellaneousItem(model);
           return RedirectToAction("Totals", new{model.QuoteId});
        }
