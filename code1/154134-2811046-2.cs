    public partial class MainForm : Form {
        public string ContentDescription {
            set {
                textBox1.Text = value.trim();
            }
        }
    }
