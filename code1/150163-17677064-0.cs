     public JsonResult ActionDateClicked(ActionViewModel vm)
            {
                vm.Model.Observation = "Changed";
                return Json(vm, JsonRequestBehavior.AllowGet);
            }
