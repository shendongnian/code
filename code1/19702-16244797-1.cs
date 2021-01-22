    using System;
    using System.Windows.Forms;
    
    namespace MyNamespace
    {
        /// <summary>
        /// Alternate form for editing string arrays in PropertyGrid control
        /// </summary>
        public partial class TextArrayPropertyForm : Form
        {
            public TextArrayPropertyForm(string[] value,
                string instructions = "Enter the strings in the collection (one per line):", string title = "String Collection Editor")
            {
                InitializeComponent();
                Value = value;
                textValue.Text = string.Join("\r\n", value);
                labelInstructions.Text = instructions;
                Text = title;
            }
    
            public string[] Value;
    
            private void buttonCancel_Click(object sender, EventArgs e)
            {
                DialogResult = DialogResult.Cancel;
            }
    
            private void buttonOK_Click(object sender, EventArgs e)
            {
                Value = textValue.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
                DialogResult = DialogResult.OK;
            }
        }
    }
