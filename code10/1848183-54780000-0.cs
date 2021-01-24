    public class DisplayLockAlert : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            MasterLockMgr lockMgr = new MasterLockMgr(new MvcFertilizerEntities(), Membership.GetUser());
            switch (lockMgr.GetMasterLockStatus())
            {
                case Status.Locked:
                    filterContext.HttpContext.Session.Add(AlertMessages.Key_Locked, AlertMessages.System_Locked);
                    break;
                default:
                    filterContext.HttpContext.Session.Remove(AlertMessages.Key_Locked);
                    break;
            }
            base.OnActionExecuted(filterContext);
        }
    }
