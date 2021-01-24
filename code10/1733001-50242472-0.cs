    public class DepartmentContext : DbContext
    {
        public DepartmentContext(
            IDepartmentRequestContext deptRequestContext, 
            IConnectionSelector connSelector) 
        : base(connSelector.GetConnectionString(deptRequestContext.SelectedDepartament))
        {
        }
    }
