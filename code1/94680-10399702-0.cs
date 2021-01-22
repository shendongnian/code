    DialogResult dlgRes = MessageBox.Show("Are you sure that you want to delete this Factor?", "DELETE ITEM?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    if (dlgRes == DialogResult.Yes)
    {
        //WBSDA.Delete(dgvR.Cells["WBSID"].Value.ToInt());
        tslMessage.Text = "Item Deleted";
    }
    else
        e.Cancel = true;
