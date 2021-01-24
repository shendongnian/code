    int sum = 0;
    string NameProfil = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Le Nom").ToString();
    for (int i = 0; i < gridView2.RowCount; i++) 
    {
        if(gridView2.GetRowCellValue(i, "Le Nom").ToString() == NameProfil)
        {
            sum += int.Parse(gridView2.GetRowCellValue(i, "Quantité").ToString());
        }
    }
    MessageBox.Show(sum + " "+ NameProfil);
