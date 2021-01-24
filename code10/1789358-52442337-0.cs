    public static void EmptyOnDuplicateData(this DataGridView dgv, string columnToEmpty)
    {
        List<string> ExistingData = new List<string>(); //I would do this with T and instead of passing string i would pass DataGridViewColumn so i could get type and other things but that is on you and i am just writing example
        foreach(DataGridViewRow row in dgv.Rows)
        {
            if(ExistingData.Contains(row.Cells[columnToEmpty].Value)) //Data from this cell already existed before this cell
            {
                row.Cells[columnToEmpty].Value == ""; //We clear that from that cell
            }
            else // Data from this cell doesn't exist anywhere before
            {
                ExistingData.Add(row.Cells[columnToEmpty].Value);
            }
        }
    }
