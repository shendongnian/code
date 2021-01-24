    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        bool isElseLoop = false;
        if (txtCategoryName.Text == string.Empty)
        {
          MessageBox.Show("Fill the textBox", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          return;
        }
        else if (txtCategoryName.Text != string.Empty)
        {
          for (int i = 0; i < dgvCategory.Rows.Count; i++)
          {
            if (dgvCategory.Rows[i].Cells[1].Value.ToString() == txtCategoryName.Text)
            {
              MessageBox.Show("Choose another name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              isElseLoop = true;
              return;
            }
          }
        }
        if (!isElseLoop)
        {
          txtCategoryId.Text = clsCat.getCategoryId().Rows[0][0].ToString();
          clsCat.addCategory(txtCategoryName.Text);
          MessageBox.Show("Done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
          txtCategoryId.Clear();
          txtCategoryName.Clear();
          dataPreview();
        }
      }
      catch
      {
        MessageBox.Show("Erroe save in category", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
    }
  
