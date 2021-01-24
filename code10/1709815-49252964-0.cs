    {
        if (e.Row.RowIndex % 4 == 0)
        {
            e.Row.Cells[0].Attributes.Add("colspan", "4");
        }
        else
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}
