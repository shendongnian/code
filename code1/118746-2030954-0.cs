    public Controller MailerController
    {
        public ActionResult Details(int mailerID)
        {
            ...
            return View(new { id = mailerID });
        }
    }
