    [HttpPost]
        public ActionResult GetAsentamiento(string CP)
        {
            var drop2 = (from p in db.CodigosPostales where p.CodigoPostal == CP select new { id = p.IdCodigoPostal, value = p.Asentamiento}).ToList();
            SelectList lista = new SelectList(drop2);
            ViewBag.lista = lista;
            return Json(ViewBag.lista);
        }
