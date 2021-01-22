    public class MyForm : Form
    {
        public MyForm()
        {
            this.Closed += delegate
            {
                MessageBox.Show("If events were weak by default, you might never see this message.");
            };
        }
    }
