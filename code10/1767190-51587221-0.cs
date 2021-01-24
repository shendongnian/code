    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridView1.IsCurrentRowDirty)
            {
                DialogResult result = MessageBox.Show("you have not saved the changes!\nDo you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }
