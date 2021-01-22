        public class BaseView<TPresenter>
            where TPresenter: IBasePresenter
        {
            TPresenter Presenter { get; set; }
        }
        public class JobView: BaseView<IJobViewPresenter>
        {
            
        }
