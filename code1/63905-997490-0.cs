            DataGridViewComboBoxColumn timeColumn = new DataGridViewComboBoxColumn();
            timeColumn.DisplayMember = "TimeOfDay";
            DateTime startTime = DateTime.Today;
            for (int i = 0; i <= 23; i++)
            {
                for (int j = 0; j <= 60; j += 15)
                {
                    timeColumn.Items.Add(startTime.AddHours(i).AddMinutes(j));
                }
            }
            this.dataGridView1.Columns.Add(timeColumn);
