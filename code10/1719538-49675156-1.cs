    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            /// <summary>
            /// The last unsaved selected item
            /// </summary>
            private object mLastSelectedValue;
            public Form1()
            {
                InitializeComponent();
                // Make it a fixed list
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                // Add some dummy items
                comboBox1.Items.Add("Item 1");
                comboBox1.Items.Add("Item 2");
                comboBox1.Items.Add("Item 3");
                comboBox1.Items.Add("Item 4");
            }
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Get the desired new value
                var newValue = ((ComboBox)sender).SelectedItem;
                // If value is the last-selected one...
                if (mLastSelectedValue == newValue)
                    // Do nothing else
                    return;
                // If this is a new selection
                if (mLastSelectedValue == null)
                {
                    // Save the new selection
                    mLastSelectedValue = newValue;
                }
                // Otherwise, the value is different...
                else
                {
                    // Restore value
                    ((ComboBox)sender).SelectedItem = mLastSelectedValue;
                    // Show message box
                    MessageBox.Show("Please save your work first");
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                // TODO: Save something
                MessageBox.Show("Saved");
                // Clear last value
                mLastSelectedValue = null;
                // Clear combo box selected item
                comboBox1.SelectedItem = null;
            }
        }
    }
