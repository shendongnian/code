    [HttpPost]
    public JsonResult AddItem([FromBody]Item item) {
        if(ModelState.IsValid) {
            try {
                var sql = @"INSERT INTO ITEMS(iModel, iName) VALUES ({0}, {1})";
                _DB.Database.ExecuteSqlCommand(sql, item.ItemModel, item.ItemName);
                return Json(new { Success = "Success" });
            } catch (Exception ex) {
                throw ex;
            }
        }
        return Json(new { Success = "BadRequest" });         
    }
