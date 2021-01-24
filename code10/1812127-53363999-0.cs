    public partial class SecondForm : Form
    {
        public SecondForm(int userId, string userName)
        {
            InitializeComponents();
            MessageBox.Show("User ID you passed is " + userId + " and it's name is " + userName);
        }
    }
