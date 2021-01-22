    [HttpPost]
    public ActionResult SaveProfile(UpdatableAppInfo postData) {
      List<object> result = new List<object>();
      // process postData here
      return Json(result);
    }
