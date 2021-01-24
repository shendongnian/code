    private void dgTeam1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pIndex = _list1.playerList.FindIndex(p => p.captain == true);
            if (e.ColumnIndex == 6)
            {
                if (pIndex != -1)
                {
                    DialogResult result = MessageBox.Show("Captain already exists! \nDo you want change?", "Change Captain Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        dgTeam1[6, pIndex].Value = "false";
                    }
                    else
                    {
                        dgTeam1[6, e.RowIndex].Value = "false";
                    }
                }
            }
        }
