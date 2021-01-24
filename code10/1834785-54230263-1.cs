    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    public void searchOnAllDatabases(string query)
    {
    MyDatabaseConnection con1 = new MyDatabaseConnection("Data Source= 10.232.1.15\\SERVER1;Initial Catalog = My Catalog;Persist Security Info=True;User ID=sa;Password=myPSW");  //----1st search here 
        MyDatabaseConnection con2 = new MyDatabaseConnection("Data Source= 10.232.1.15\\SERVER2;Initial Catalog = My Catalog;Persist Security Info=True;User ID=sa;Password=myPSW");  //---- 2nd search here 
        MyDatabaseConnection con3 = new MyDatabaseConnection("Data Source= 10.232.1.15\\SERVER3;Initial Catalog = My Catalog;Persist Security Info=True;User ID=sa;Password=myPSW");  //---- 3rd search here 
    MyDatabaseConnection[] cons = new MyDatabaseConnection[] { con1, con2, con3 };
    foreach (MyDatabaseConnection con in cons)
    {
        var result = con.execute(query);
        if (result)
           break;
    }
     }
    }
