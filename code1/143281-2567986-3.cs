        public interface IBaseView
        {
            IBasePresenter BasePresenter { get; }
        }
        public class BaseView<TPresenter> : IBaseView
            where TPresenter: IBasePresenter
        {
            TPresenter Presenter { get; set; }
            IBasePresenter IBaseView.BasePresenter
            {
                get { return Presenter; }
            }
        }
