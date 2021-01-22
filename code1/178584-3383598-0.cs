    private void DeleteToolStripButton_Click(object sender, EventArgs e)
    {
        long ThisRow = Convert.ToInt64((radGridView1.CurrentRow.Cells["ID"].Value));
        DialogResult DelEntry = MessageBox.Show("Do you want to delete the entry titled '" + radGridView1.CurrentRow.Cells["SparesTitle"].Value + "'?", "Delete this entry?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        switch (DelEntry)
        {
            case DialogResult.OK:
                // Locate row for deletion
                VSConnectorDataSet.TestTableRow oldTestTableRow;
                oldTestTableRow = vSConnectorDataSet.TestTable.FindByID(ThisRow);
                // Delete the row from the dataset
                oldTestTableRow.Delete();
                // Delete from database
                this.testTableTableAdapter1.Update(this.vSConnectorDataSet.TestTable);
                break;
                //
                // To Do - Give Slected to another row; having just deleted our 'CurrentRow'
                //
            case DialogResult.Cancel:
                break;
        }
    }
