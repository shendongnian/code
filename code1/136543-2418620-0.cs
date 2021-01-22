    private void gridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
    {
        if (ConditionIsMet())
        {
            e.Graphics.Clear(e.Appearance.BackColor);
            e.Handled = true;
        }
    }
