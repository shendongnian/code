    private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (currId == 0)
                    return;
                _personList.RemoveAll(x => x.Id == currId);
                _personList.Add(MapProperties(currId, tbFirstName.Text, tbLastName.Text, tbEmail.Text,
                    dtDateOfBirth.Value));
                this.PopulateGrid();
                MessageBox.Show("Data successfully updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
