    class Form1 : Form
    {
        List<Employee> _list;  
        string GetEmployeeName(List<Employee> list, string id)
        {
            var e = list.Single( e => e.Id == id );
            return e.Name;
        }
    }
