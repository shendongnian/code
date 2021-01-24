        public async Task<JsonResult> Delete(int? id)
        {
            if (id == null)
            {
                return Json(-1);
            }
            var offAgenda = await CommonService.GetDocument(id);
            if (offAgenda == null)
            {
                return Json(-1);
            }
            if (0 == await AdminService.DeleteDocument((int)id))
            {
                return Json(1);
            }
            return Json(-1);
        }
