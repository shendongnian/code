    // your reusable MVP framework project 
    public abstract class IPresenter<V> // OK may be a better name here
    {
        protected V View { get; }
 
        protected IPresenter()
        {
            View = ...; // dependenchy injection or some basic reflection, or pass in view to ctor
            (View as dynamic).Presenter = this;
        }
    }
    public interface IView<P>
    {
        P Presenter { get; set; }
    }
 
    // your presentation project
    public interface IEmployeeView : IView<EmployeePresenter>
    {
        void OnSave(); // some view method
    }
    public class EmployeePresenter : IPresenter<IEmployeeView>
    {
        public void Save()
        {
            var employee = new EmployeeModel
            {
                Name = View.Bla // some UI element property on IEmployeedView interface
            };
            employee.Save();
        }
    }
 
    // your view project
    class EmployeeView : IEmployeeView
    {
        public EmployeePresenter Presenter { get; set; } // enforced
 
        public void OnSave()
        {
            Presenter.Save();
        }
    }
 
