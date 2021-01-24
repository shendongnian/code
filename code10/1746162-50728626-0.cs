        public ActionResult View1()
        {
            MyModel model = new MyModel();
            model.Type = 1;
            return View(model);
        }
        public ActionResult View2()
        {
            MyModel model = new MyModel();
            model.Type = 2;
            return View(model);
        }
