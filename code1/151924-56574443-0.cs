    // your reusable MVP framework project 
    public interface IPresenter<V>
    {
        V View { get; set; }
    }
    public interface IView<P>
    {
        P Presenter { get; }
    }
    public static class PresenterFactory
    {
        public static P Presenter<P>(this IView<P> view) where P : new()
        {
            var p = new P();
            (p as dynamic).View = view;
            return p;
        }
    }
 
    // your presentation project
    public interface IEmployeeView : IView<EmployeePresenter>
    {
        void OnSave(); // some view method
    }
    public class EmployeePresenter : IPresenter<IEmployeeView>
    {
        public IEmployeeView View { get; set; } // enforced
         
        public void Save()
        {
            var employee = new EmployeeModel
            {
                Name = View.Bla // some UI element property on IEmployeeView interface
            };
            employee.Save();
        }
    }
 
    // your view project
    class EmployeeView : IEmployeeView
    {
        public EmployeePresenter Presenter { get; } // enforced
 
        public EmployeeView()
        {
            Presenter = this.Presenter(); // type inference magic
        }
 
        public void OnSave()
        {
            Presenter.Save();
        }
    }
 
