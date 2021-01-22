    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    namespace JoinAndGroupDemo
    {
        public class DataSource
        {
            private DataSet _DS;
            public DataSource()
            {
                CreateDataSet();
            }
            private void CreateDataSet()
            {
                _DS = new DataSet();
                DataTable emp = _DS.Tables.Add("Employees");
                DataTable grp = _DS.Tables.Add("Groups");
                InitTable(emp);
                InitTable(grp);
                DataTable assoc = _DS.Tables.Add("EmployeeGroups");
                assoc.Columns.Add("empId", typeof (int));
                assoc.Columns.Add("grpId", typeof (int));
                _DS.Relations.Add(new DataRelation("FK_EmployeeGroups_Employees", 
                    emp.Columns["id"], assoc.Columns["empId"]));
                _DS.Relations.Add(new DataRelation("FK_EmployeeGroups_Groups", 
                    grp.Columns["id"], assoc.Columns["grpId"]));
                assoc.Columns.Add("emp_name");
                assoc.Columns["emp_name"].Expression = "Parent(FK_EmployeeGroups_Employees).name";
                assoc.Columns.Add("grp_name");
                assoc.Columns["grp_name"].Expression = "Parent(FK_EmployeeGroups_Groups).name";
                emp.Rows.Add(new object[] { 1, "Malcolm Reynolds"});
                emp.Rows.Add(new object[] { 2, "Zoe Washburne" });
                emp.Rows.Add(new object[] { 3, "Hoban Washburne" });
                emp.Rows.Add(new object[] { 4, "Irina Serra" });
                emp.Rows.Add(new object[] { 5, "Jayne Cobb" });
                emp.Rows.Add(new object[] { 6, "Kaylee Frye" });
                emp.Rows.Add(new object[] { 7, "Simon Tam" });
                emp.Rows.Add(new object[] { 8, "River Tam" });
                emp.Rows.Add(new object[] { 9, "Derrial Book" });
                grp.Rows.Add(new object[] { 1, "Command"});
                grp.Rows.Add(new object[] { 2, "Combat" });
                grp.Rows.Add(new object[] { 3, "Operations" });
                grp.Rows.Add(new object[] { 4, "Other" });
                assoc.Rows.Add(new object[] { 1, 1 });
                assoc.Rows.Add(new object[] { 2, 1 });
                assoc.Rows.Add(new object[] { 1, 2 });
                assoc.Rows.Add(new object[] { 2, 2 });
                assoc.Rows.Add(new object[] { 5, 2 });
                assoc.Rows.Add(new object[] { 8, 2 }); // spoiler alert!
                assoc.Rows.Add(new object[] { 3, 3 });
                assoc.Rows.Add(new object[] { 6, 3 });
                assoc.Rows.Add(new object[] { 4, 4 });
                assoc.Rows.Add(new object[] { 7, 4 });
                assoc.Rows.Add(new object[] { 8, 4 });
                assoc.Rows.Add(new object[] { 9, 4 });
                emp.Columns.Add("groups", typeof (string));
                foreach (DataRow empRow in emp.Rows)
                {
                    empRow["groups"] = string.Join(
                        ", ",
                        empRow
                            .GetChildRows("FK_EmployeeGroups_Employees")
                            .AsEnumerable()
                            .Select(x => (string) x["grp_name"])
                            .ToArray());
                }
                grp.Columns.Add("employees", typeof(string));
                foreach (DataRow grpRow in grp.Rows)
                {
                    grpRow["employees"] = string.Join(
                        ", ",
                        grpRow
                            .GetChildRows("FK_EmployeeGroups_Groups")
                            .AsEnumerable()
                            .Select(x => (string)x["emp_name"])
                            .ToArray());
                }
            }
            private void InitTable(DataTable t)
            {
                t.Columns.Add("id", typeof (int));
                t.Columns.Add("name", typeof (string));
                // this is required by DataRelations
                t.PrimaryKey = new DataColumn[] { t.Columns["id"]};
            }
            public IList Employees
            {
                get
                { return ((IListSource)_DS.Tables["Employees"]).GetList(); }
            }
            public IList Groups
            {
                get { return ((IListSource)_DS.Tables["Groups"]).GetList(); }
            }
            public IList EmployeeGroups
            {
                get { return ((IListSource)_DS.Tables["EmployeeGroups"]).GetList(); }            
            }
        }
    }
