    public class NHibernateSessionAttribute : ActionFilterAttribute
    {
        public NHibernateSessionAttribute()
        {
            Order = 100;
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.IsChildAction) return;
             SessionSource.EndContextSession();
        }
    }
