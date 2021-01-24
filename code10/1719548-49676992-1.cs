       [HttpGet]
        public JsonResult FetchCoIds(string CoName)
        {
            var data = new { Value = "val", Text = CoName+"_val1" };
            JsonResult jResult = new JsonResult();
            jResult .Data = data;
            jResult .JsonRequestBehavior = JsonRequestBehavior.AllowGet;    
            return jResult ;
        }
           
