    public ActionResult IsSerialAvailable(string Serial)
        {
            using (db)
            {
                try
                {
                    var actionName = HttpContext.Request.UrlReferrer.Segments[2];
                    var serial = db.Items.Single(i => i.Serial == Serial);
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
        }
