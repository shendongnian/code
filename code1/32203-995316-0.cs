    enter code here
        public ActionResult UpdateStatus(int contactId, Status contactStatus)
        {
            ContactRepository repo = new ContactRepository();
            repo.UpdateStatus(contactId, contactStatus);
            return Json("success:true");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ActionName("RefreshAjaxList")]
        public ActionResult RefreshContact()
        {
            ContactRepository repo = new ContactRepository();
            IList<Contact> list = repo.List();
            return PartialView("AjaxUc/AjaxList", repo.List());
        }
