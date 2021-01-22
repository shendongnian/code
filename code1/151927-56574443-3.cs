    // your reusable MVP framework project
    public abstract class IPresenter<V> where V : IView
    {
        protected V View { get; }
 
        protected IPresenter()
        {
            View = ...; // dependenchy injection or some basic reflection, or pass in view to ctor
            WireEvents();
        }
 
        protected abstract void WireEvents();
    }
 
    // your presentation project
    public interface IEmployeeView : IView
    {
        // events helps in observing
        event Action OnSave; // for e.g.
    }
    public class EmployeePresenter : IPresenter<IEmployeeView>
    {
        protected override void WireEvents()
        {
            View.OnSave += OnSave;
        }
         
        void OnSave()
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
        public event Action OnSave;
        void OnClicked(object sender, EventArgs e) // some event handler
        {
            OnSave();
        }
    }
    // you kick off like new EmployeePresenter()....
 
