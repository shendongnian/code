    double Sum = 0;
    int countColumn = DgvPV.ColumnCount;
    int countRow = DgvPV.RowCount;
    int column = countColumn - 4;
    for (int i = 0; i < countRow; i++)
    {
        Sum = 0; // Your bug was right here
        for (int j = 3; j < column; j++)
        {
            Sum += Convert.ToDouble(DgvPV.Rows[i].Cells[j].Value.ToString());
            DgvPV.Rows[i].Cells["Total"].Value = Sum;
        }
    }
    for (int i = 1; i < DgvPV.RowCount; i++)
    {
        DgvPV.Rows[i].Cells["Total"].Value = Convert.ToDouble(DgvPV.Rows[i].Cells["Total"].Value.ToString()) - Convert.ToDouble(DgvPV.Rows[i - 1].Cells["Total"].Value.ToString());
    }            
