    public JsonResult FakulteBolumDrop(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Bolum> bolum = db.Bolum.Where(b => b.FakulteId == id).ToList();
            return Json(bolum, JsonRequestBehavior.AllowGet);
        }
