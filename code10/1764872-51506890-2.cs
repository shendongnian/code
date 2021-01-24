        public JsonResult Delete(int? id)
        {
            if (id == null)
            {
                return Json(-1);
            }
            var document = CommonService.GetDocument(id);
            if (document == null)
            {
                return Json(-1);
            }
            if (0 == AdminService.DeleteDocument((int)id))
            {
                return Json(1);
            }
            return Json(-1);
        }
