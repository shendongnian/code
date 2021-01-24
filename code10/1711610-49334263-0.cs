            var keys = new List<string>();
            for (int i = 0; i < dgvTableInfo.Rows.Count - 1; i++)
            {
                var userID = dgvTableInfo.Rows[i].Cells["UserID"].Value.ToString();
                var plantName = dgvTableInfo.Rows[i].Cells["PlantID"].Value.ToString();
                var key = userID + plantName;
                if (!keys.Contains(key))
                {
                    keys.Add(key);
                }                
                else
                {
                    GESDialogBox.Show(this, @"User with same userid and plantid is already exist, please choose unique userid and plantid ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
