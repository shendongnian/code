    int i;
    i = gridViewParts.Rows.Add( new gridViewParts.Rows.Add(row););
        
    DataGridViewCell cellQuantity = new DataGridViewTextBoxCell();
    cellQuantity.Value = item.Quantity;
    gridViewParts.Rows[i].Cells["colQuantity"] = cellQuantity;
