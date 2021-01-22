    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var c = Connect();
            var da = new SQLiteDataAdapter("select emp_id, emp_firstname, emp_lastname from emp where 1 = 0", c);
            
            var b = new SQLiteCommandBuilder(da);
            da.InsertCommand = new SQLiteCommand(
                @"insert into emp(emp_firstname, emp_lastname ) values(:_emp_firstname, :_emp_lastname);
                select emp_id /* include rowversion field here if you need */ from emp where emp_id = last_insert_rowid();", c);
            da.InsertCommand.Parameters.Add("_emp_firstname", DbType.String, 0, "emp_firstname");
            da.InsertCommand.Parameters.Add("_emp_lastname", DbType.String, 0, "emp_lastname");
            da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
            da.UpdateCommand = b.GetUpdateCommand();
            da.DeleteCommand = b.GetDeleteCommand();
            var dt = new DataTable();
            da.Fill(dt);
            var nr = dt.NewRow();
            nr["emp_firstname"] = "john";
            nr["emp_lastname"] = "lennon";
            dt.Rows.Add(nr);
            da.Update(dt);
            dt.AcceptChanges();
            nr["emp_lastname"] = "valjean";
            da.Update(dt);
        }
        SQLiteConnection Connect()
        {
            return new SQLiteConnection(@"Data Source=../../test.s3db;Version=3;");
        }
    }
