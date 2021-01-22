    public JsonResult JsonDataResult(object data, string optionalMessage = "")
        {
            return Json(new { data = data, status = "success", message = optionalMessage }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JsonSuccessResult(string message)
        {
            return Json(new { data = "", status = "success", message = message }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JsonErrorResult(string message)
        {
            return Json(new { data = "", status = "error", message = message }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JsonRawResult(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }
