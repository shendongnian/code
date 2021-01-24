    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    public void searchOnAllDatabases(string query)
    {
    MyDatabaseConnection con1 = new MyDatabaseConnection("Server=other_server11");
    MyDatabaseConnection con2 = new MyDatabaseConnection("Server=other_server");
    MyDatabaseConnection con3 = new MyDatabaseConnection("Server=third_one");
    MyDatabaseConnection[] cons = new MyDatabaseConnection[] { con1, con2, con3 };
    foreach (MyDatabaseConnection con in cons)
    {
        con.execute(query);
    }
     }
    }
