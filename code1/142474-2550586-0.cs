    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            List<User> users = new List<User>();
            users.Add(new User(){Name = "Fred", Id = 1});
            users.Add(new User(){Name = "Jill", Id = 2});
            users.Add(new User(){Name = "Bob", Id = 3});
            List<Account> accounts = new List<Account>();
            accounts.Add(new Account(){AccountName = "Mr Smith", UserId = 1});
            accounts.Add(new Account() { AccountName = "Ms Brown", UserId = 2 });
            accounts.Add(new Account() { AccountName = "Mr Smith 2", UserId = 1 });
            dataGridView1.DataSource = accounts;
            DataGridViewTextBoxColumn col1 = dataGridView1.Columns[1] as DataGridViewTextBoxColumn;
            col1.DataPropertyName = "AccountName";
            DataGridViewComboBoxColumn col = dataGridView1.Columns[0] as DataGridViewComboBoxColumn;
            col.DataSource = users;
            col.DisplayMember = "Name";
            col.DataPropertyName = "UserId";
            col.ValueMember = "Id";
        }
            
    }
    public class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class Account
    {
        public string AccountName { get; set; }
        public int UserId { get; set; }
    }
