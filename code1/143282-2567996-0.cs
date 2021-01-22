    public interface IBasePresenter
    {
    }
    public interface IJobViewPresenter : IBasePresenter
    {
    }
    public interface IActivityViewPresenter : IBasePresenter
    {
    }
    
    public class BaseView : IBasePresenter
    {
    }
    
    public class JobView : BaseView, IJobViewPresenter
    {
    }
    
    public class ActivityView : BaseView, IActivityViewPresenter
    {
    }
