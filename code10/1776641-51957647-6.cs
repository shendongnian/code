    class Form1 : Form
    {
        List<Employee> _list;  
        public Form1()
        {
            _list = GetEmployees();
            this.MyList.DataSource = _list;
        }
        void ShowEmployeeName(string id)
        {
            var e = _list.Single( e => e.Id == id );
            this.NameLabel.Text = e.Name;
        }
    }
