    // your presentation project
    public interface IEmployeeView
    {
        void OnSave(); // some view method
    }
    public static class EmployeePresenter // OK may need a better name
    {
        public void Save(this IEmployeeView view)
        {
            var employee = new EmployeeModel
            {
                Name = view.Bla // some UI element property on IEmployeedView interface
            };
            employee.Save();
        }
    }
 
    // your view project
    class EmployeeView : IEmployeeView
    {       
        public void OnSave()
        {
            this.Save(); // that's it. power of extensions.
        }
    }
 
