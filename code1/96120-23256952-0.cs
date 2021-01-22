    public class Form2 : Form
    {
        private string oldText;
        
        public Form2(string newText):this()
        {
            oldText = newText;
            btnSubmit.DialogResult = DialogResult.OK;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = oldText;
        }
        public string getText()
        {
            return textBox1.Text;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
