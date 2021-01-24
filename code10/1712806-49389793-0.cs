    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    
    namespace RegexInputValidation
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }        
            private void textBoxInput_TextChanged(object sender, EventArgs e)
            {
                string regex = @"^((\d{0,2}(\.\d{1,6})?)|(\.\d{1,6}))$";
                bool isValid = (Regex.IsMatch(textBoxInput.Text, regex) && !textBoxInput.Text.Contains(" ") && !textBoxInput.Text.Equals(""));
                
                if (isValid)
                    textBoxValid.Text = "Valid input: " + double.Parse(textBoxInput.Text);
                else
                    textBoxValid.Text = "TBD";
            }
        }
    }
