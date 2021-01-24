    class EmployeeList : List<Employee>
    {
        public Func1() {  DoSomething(); }
    }
    class Form1 : Form
    {
        protected EmployeeList _list;
        public void button1_click(object sender, EventArgs e)
        {
            _list.Func1();
        }
    }   
