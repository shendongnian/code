    object buffer[4];
    List<DataGridViewRow> rows = new List<DataGridViewRow>;
    foreach (SaleItem item in this.Invoice.SaleItems)
                {
                    buffer[0] = item.Quantity;
                    buffer[1] = item.Part.Description;
                    buffer[2] = item.Price;
                    buffer[3] = item.Quantity * item.Price;
                    buffer[4] = item.Part.Number;
                    rows.Add(new DataGridViewRow);
                    rows(rows.Count - 1).CreateCells(gridViewParts, buffer);
                }
    gridViewParts.Rows.AddRange(rows.ToArray());
