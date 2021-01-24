    int sum = 0;
    string NameProfil = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Le Nom").ToString();
    for (int i = 0; i < gridView2.RowCount; i++) 
    {
        if(gridView2.GetRowCellValue(i, "Le Nom") == NameProfil)
        {
            sum += int.Parse(Convert.ToString(gridView2.GetRowCellValue(i, "Quantité")));
        }
    }
    MessageBox.Show(sum.ToString() + " "+ NameProfil);
