        [HttpPost]
        public JsonResult TestFunction([FromBody]string FName)
        {
            return Json(new
            {
                result = "Ok"
            });
        }
