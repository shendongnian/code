    public class _Default : ViewBasePage<Presenter<IView>, IView>
    {
        #region Overrides of classB
        public override void test()
        {
            //perform the test steps.
        }
        #endregion
    }
    public abstract class ViewBasePage<TPresenter, TView> :
        Page, IView
        where TPresenter : Presenter<TView>
        where TView : IView
    {
        #region Implementation of IView
        public IView proveCast()
        {
            return (IView)this;
        }
        public abstract void test();
        #endregion
    }
    public interface IView
    {
        void test();
    }
    public abstract class Presenter<TView> where TView : IView
    {
        public TView View { get; set; }
        public virtual void OnViewInitialized(){}
        public virtual void OnViewLoaded(){}
    }
