    public class MyController : MyBaseController
    {
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Item item)
        {
            DataContext.Items.Attach(item);
            DataContext.SubmitChanges();
    
            return View(item);
        }
    }
