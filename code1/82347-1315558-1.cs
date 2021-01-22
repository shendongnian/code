    class MyController : Controller
    {
        [LocalPermittedAuthorize]
        public ActionResult Fire()
        {
            Missile.Fire(Datetime.Now);
        }
    }
