        public ActionResult UpdateContent(FormCollection preview = null)
        {
            return View(preview);
        }
        [HttpPost]
        public ActionResult UpdateContent(FormCollection collection = null, bool preview = false)
        {
            if (preview)
                return UpdateContent(collection);
            else
                return UpdateContent(null);
        }
