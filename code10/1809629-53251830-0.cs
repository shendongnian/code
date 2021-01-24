    Parallel.For(0, NumDia, (i, state) =>
        {
            aImageButton[i] = new ImageButton();
            aImageButton[i].ID = "ImageButton" + (i + 1);
            .....
            TableCell cell = new TableCell();
            cell.Controls.Add(aImageButton[i]);
            row.Cells.Add(cell);
        });
