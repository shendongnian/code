    public partial class SecondForm : Form
    {
        public SecondForm()
        {
            // All your code
        }
        public void SwitchUser(int userId, string userName)
        {
            textbox1.Text = userId.ToString();
            textbox2.Text = userName;
        }
    }
