            protected string GetEvents()
        {
            //DATABASE READOUT
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var events = dc.Events.ToList();
                JsonResult json = new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                return new JavaScriptSerializer().Serialize(json.Data);
            }
        }
