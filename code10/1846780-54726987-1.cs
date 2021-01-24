    [AcceptVerbs("Post")]
    public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, ActivityHeader activity)
    {
                if (activity != null )
                {
                    UpdateActivity(activity);
                }
    
                return Json(new[] { activity }.ToDataSourceResult(request, ModelState));
    }
