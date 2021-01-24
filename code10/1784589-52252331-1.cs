        [HttpPost]
        public JsonResult UpdateValue(string chkId, string chkValue)
        {
            dynamic result = string.Empty;
           
            try
            {
                //Code to update value in DB
                result = new
                {
                    message = "",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                result = new
                {
                    message = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
           return Json(returnResult);
        }
