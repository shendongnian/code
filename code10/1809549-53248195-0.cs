    if (exp <= System.DateTime.Now)
    {
        row.CellStyle.ForeColor = Color.White;
        row.CellStyle.BackColor = Color.Red;
    }
    else
    {
        row.CellStyle.ForeColor = Color.Black;
        row.CellStyle.BackColor = Color.White;       // or some other origin color
    }
