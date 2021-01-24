    public class MainForm : MainForm
    {
        config c = new config();
        private Button1_Click(object sender, EventArgs e)
        {
            c.Show();
        }
        private string cmdMake(int cmd, int rw)
        {
            double val = double.Parse(c.Property);
        }
    }
