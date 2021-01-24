    DateTime? postedDate = null;
    if(!System.Convert.IsDBNull(selectedRow.Cells[2].Value))
    {
        postedDate = Convert.ToDateTime(selectedRow.Cells[2].Value);
    }
