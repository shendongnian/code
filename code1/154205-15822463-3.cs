    private void btExit_Click(object sender, EventArgs e)
            {
                if (cONTRACTERDataGridView.Tag.Equals("1"))
                {
                    if (MessageBox.Show("Do you want to save the changes..!?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        cONTRACTERBindingNavigatorSaveItem_Click(null, null);
                }
                this.Close();
            }
