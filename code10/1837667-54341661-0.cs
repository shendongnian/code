    [HttpPost]
        public ActionResult getName(string Name)
        {
            string SecondString = "secondString";
            return Json(new { Name, SecondString });
        }
