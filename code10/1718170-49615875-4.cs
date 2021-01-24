    [HttpGet]
    public ActionResult AjaxChart() {
        IEnumerable<DBContent> contents = db.DBContents;
        var delayedResponses = contents.Where(r => r.DelayedResponseTime != 0)
                                       .Select(x => x.DelayedResponseTime);
        var commonResponses = contents.Where(r => r.CommonResponseTime != 0)
                                      .Select(x => x.CommonResponseTime);
        var ContentIds = new List<int>();
        for (var i = 1; i <= delayedResponses.Count(); i++) {
            ContentIds.Add(i);
        }
        var result = new {
            DelayedResponseTimes = delayedResponses.ToList(),
            CommonResponseTimes = commonResponses.ToList(),
            ContentIds = ContentIds
        };
        return Json(result, JsonRequestBehavior.AllowGet);
    }
