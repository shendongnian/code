    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                if(e.CurrentValue == CheckState.Checked)
                {
                    var result = MessageBox.Show("Really Remove?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        e.NewValue = e.CurrentValue;
                    }
                }
            }
