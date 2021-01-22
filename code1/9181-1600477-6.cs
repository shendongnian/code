    List<DataGridViewRow> rows = new List<DataGridViewRow>();
    foreach (SaleItem item in this.Invoice.SaleItems)
    {
        rows.Add(new DataGridViewRow());
        rows[rows.Count - 1].CreateCells(gridViewParts,
            item.Quantity,
            item.Part.Description,
            item.Price,
            item.Quantity * item.Price,
            item.Part.Number
        );
    }
    gridViewParts.Rows.AddRange(rows.ToArray());
