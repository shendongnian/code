     public JsonResult GetFruits()
        {
            return Json(new List<object>
            {
                new {
                        Color="Red",
                        Name="Apple",
                        Shape="Round"
                    }
            }, JsonRequestBehavior.AllowGet);
        }
