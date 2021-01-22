    private bool HasErrorText()
        {
            bool hasErrorText = false;
            //replace this.dataGridView1 with the name of your datagridview control
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ErrorText.Length > 0)
                    {
                        hasErrorText = true;
                        break;
                    }
                }
                if (hasErrorText)
                    break;
            }
            return hasErrorText;
        }
