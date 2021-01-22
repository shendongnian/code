    partial class App3_EMPLOYEE
    {
        public void Detach()
        {
            this._APP3_EMPLOYEE_EXTs = default(EntityRef<APP3_EMPLOYEE_EXT>);
        }
    }
     public int updateEmployee(App3_EMPLOYEE employee)
    {
        AppEmployeeDataContext db = new AppEmployeeDataContext();
        employee.Detach();
        db.App3_EMPLOYEEs.Attach(employee,true);
        db.SubmitChanges();
        return employee.PKEY;
    }
