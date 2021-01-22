    public static class ControllerExtentions
    {
        [NonAction]
        public static bool IsResubmit (this System.Web.Mvc.ControllerBase controller, NoResubmitAbstract vModel)
        {
            return (Guid)controller.TempData["PreventResubmit"]!= vModel.PreventResubmit;
        }
        [NonAction]
        public static void PreventResubmit(this System.Web.Mvc.ControllerBase controller, params NoResubmitAbstract[] vModels)
        {
            var preventResubmitGuid = Guid.NewGuid();
            controller.TempData["PreventResubmit"] = preventResubmitGuid ;
            foreach (var vm in vModels)
            {
                vm.SetPreventResubmit(preventResubmitGuid);
            }
        }
    }
