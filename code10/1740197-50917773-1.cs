        public JsonResult GetSeries(string productLine)
        {
            db.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            List<SelectListItem> series = (from s in db.Series
                                            where s.ProductLineName == productLine
                                            select new SelectListItem { Value = s.SeriesName, Text = s.SeriesName }).Distinct().ToList();
            return Json(series, JsonRequestBehavior.AllowGet);
        }
        public List<ProductLine> GetProductLines()
        {
            db.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            var productLineList = (from p in db.ProductLines
                                   select p).ToList();
            return productLineList;
        }
        public ActionResult RequestForm()
        {
            var productLineList = new List<SelectListItem>();
            foreach (var item in GetProductLines())
            {
                productLineList.Add(new SelectListItem { Text = item.ProductlineName, Value = item.ProductlineName });
            }
            db.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            var requestViewModel = new RequestViewModel { SMRMaster = new SMRMaster(), Engineers = GetEngineers(), ProductLines = productLineList };
            return View(requestViewModel);
        }
