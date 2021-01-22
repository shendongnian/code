        public ActionResult FirstAction()
        {
            // Do FirstAction stuff here.
            return this.SecondAction(ArgumentsIfAny);
        }
        public ActionResult SecondAction()
        {
            // Do SecondAction stuff here.
            return View();
        }
