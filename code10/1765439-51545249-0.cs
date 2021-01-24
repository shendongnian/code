     [HttpPost]
        public ActionResult GetAsentamiento(string CP)
        {
            var drop2 = (from p in db.CodigosPostales where p.CodigoPostal == CP select new { Value = p.IdCodigoPostal, Text= p.Asentamiento }).ToList();
            SelectList lista = new SelectList(drop2);
            return Json(lista.Items);
        }
