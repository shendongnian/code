       [HttpGet]
        public JsonResult FetchCoIds(string CoName)
        {
            var data = new { Value = "val", Text = CoName+"_val1" };
            JsonResult jResult = new JsonResult();
            jResult.Data = data;
            jResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;    
            return jResult ;
        }
          **Note: This is for Asp.net MVC Based application. not sure you are using MVC or Core?** 
