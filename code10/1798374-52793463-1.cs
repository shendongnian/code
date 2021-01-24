    private void toolStripComboBox1_Click(object sender, EventArgs e)
            {
                toolStripComboBox1.ComboBox.SelectionChangeCommitted += ComboBoxOnSelectionChangeCommitted;
            }
    
    
    private void ComboBoxOnSelectionChangeCommitted(object o, EventArgs eventArgs)
            {
                switch (toolStripComboBox1.SelectedIndex)
                {
                    case 0:
                        richTextBox1.SelectionFont = new Font("Comic Sans MS", 12);
                        break;
                    case 1:
                        richTextBox1.SelectionFont = new Font("Comic Sans MS", 19);
                        break;
                    default:
                        richTextBox1.SelectionFont = new Font("Comic Sans MS", 9);
                        break;
                }
            }
