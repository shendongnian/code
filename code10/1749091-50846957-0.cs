    public class MyDialog: Form
    {
        public MyDialog(string prompt, int timeout)
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.Font = new Font("Times new Roman", 14f, FontStyle.Bold);
            rtb.Text = prompt;
            this.Controls.Add(rtb);
            var _Timer = new System.Windows.Forms.Timer()
            {
                Enabled = true,
                Interval = timeout
            };
            _Timer.Tick += (s, e) => this.Close();
            this.Show();
        }
    }
