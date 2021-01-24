    [HttpPost]
        public ActionResult EditCP(MyCustomModel cpa, int id)
        {
            _context.UpdateParkletApplication(cpa, id);
            return RedirectToAction("CPDashboard");
        }
