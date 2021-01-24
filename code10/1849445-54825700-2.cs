    Table[] tab = new Table[dgvSale.Rows.Count()];
    int i = 0;
    foreach (DataGridViewRow row in dgvSale.Rows)
    {
       tab[i] = new Table(); //Or another valid constructor for this class
       tab[i].Stock = row.Cells[0].Value.ToString();
       tab[i].Impure = Decimal.TryParse(row.Cells[1].Value.ToString(), out decimal value1) ? value1 : 0;
       tab[i].Pure = Decimal.TryParse(row.Cells[2].Value.ToString(), out decimal value2) ? value2 : 0;
       tab[i].Labor = Int.TryParse(row.Cells[3].Value.ToString(), out int value3) ? value3 : 0;
       i++;
    }
