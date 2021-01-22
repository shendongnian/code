     public static class SettingControl
    {
        public static void ToUpperCaseTextChanged(this TextBoxBase textBox)
        {
            textBox.Text = textBox.Text.ToUpper();
            int pos = textBox.Text.Length;
            textBox.Select(pos, pos);
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void TextBox1TextChanged(object sender, EventArgs e)
        {
            textBox1.ToUpperCaseTextChanged();
        } 
    }
