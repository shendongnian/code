    public partial class Form1 : Form
    {
        private Employee emp;
        public Form(int EmployeeID)
        {
            InitializeComponents();
            //Creating new object of Employee but with constructor that will automatically load variables into it.
            emp = new Employee(EmployeeID);
            //Checking to see if employee is loaded since if there was no employee with given ID it would return null
            if(emp.Id == null || < 1)
            {
                DialogResult dr = MessageBox.Show("Employee doesn't exist. Do you want to create new one?", "Confirm", MessageBoxButtons.YesNo);
                if(dr == DialogResult.No)
                {
                    //User doesn't want to create new employee but since there is no employee loaded we close form
                    this.Close();
                }
                else
                {
                    Employee.Create("New Employee");
                    MessageBox.Show("New employee created");
                    //Here we need to load this employee with code like emp = new Employee(newEmployeeId);
                    //To get new employee id you have 2 options. First is to create function inside Employee class that will Select MAX(ID) from Employee and return it. (bad solution)
                    //Second solution is to return value upon creating new employee so instead function `public static void Create()` you need to have `public static int Create()` so it returns newly created ID of new row in SQL database. I won't explain it since you are new and it will be too much information for now. You will easily improve code later. For now you can use Select Max(id) method
                }
            }
            textBox1.Text = emp.Id;
            textBox2.Text = emp.Name;
        }
        private void OnButton_Save_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to save changes?", "Save", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                 emp.Save();
            }
            else
            {
                //Here create private Reload function inside form that will do emp = Employee(emp.Id) and then set UI again.
            }
        }
        private void OnButton_CreateNewEmployee_Click(object sender, EventArgs e)
        {
            Employee.Create("New Employee");
            int newEmpID = something; //As i said up create method to select MAX ID or update SQL inside Create function to return newly created ID
            //I am using using since after form closes it automatically disposes it
            using(Form1 f = new Form1(newEmpID))
            {
                f.showDialog()
            }
            this.Close();
        }
    }
