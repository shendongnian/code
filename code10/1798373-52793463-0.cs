    private void toolStripComboBox1_Click(object sender, EventArgs e)
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
