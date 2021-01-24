    for(int i = 0; i < alpaGrid.Rows; i++)
    {
        DataGridViewRow row = alpaGrid.Rows[i];
        DateTime date = Convert.ToDateTime(row["Timestamp"].Value); //"Timestamp" is your column name
        if(date < .....)
            row.Visible = false;
        else
            row.Visible = true;
    }
