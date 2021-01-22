    public class MyView: IView
    {
        private MyPresenter Presenter;
    
        private OnEvent()
        {
            Presenter.DoSomething();
        }
    
        public string MyProperty
        {
            get{ return UIControl.Property;}
            set{ UIControl.Property = value}
        }
    }
    
    public interface IView
    {
        public string MyProperty{ get; set;}
    }
    
    public class MyPresenter
    {
        private IView view;
    
        public void DoSomething()
        {
            ...
            view.MyProperty = something;   
        }
    }
