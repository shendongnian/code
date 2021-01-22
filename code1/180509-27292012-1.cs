     ICellStyle cellDateStyle = workBook.CreateCellStyle(); //create custom style
     cellDateStyle.DataFormat = workBook.CreateDataFormat().GetFormat("dd/mm/yyyy"); //set day time Format
     eRow.CreateCell(3).SetCellValue(Convert.ToDateTime(row["Date"])); //set DateTime value to cell
                        eRow.GetCell(6).CellStyle = cellDateStyle; // Restyle cell using "cellDateStyle"
    I hope it helps
