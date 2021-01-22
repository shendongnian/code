    public class PagesController : Controller
    {
        static DateTime dateTimeField;
        UnitOfWork db = new UnitOfWork();
        // GET:
        public ActionResult Edit(int? id)
        {
            Page page = db.pageRepository.GetById(id);
            dateTimeField = page.DateCreated;
            return View(page);
        }
        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Page page)
        {
            page.DateCreated = dateTimeField;
            db.pageRepository.Update(page);
            db.Save();
            return RedirectToAction("Index");
        }
    }
