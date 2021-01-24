    Table[] tab = new Table[dgvSale.Rows.Count()];
    int i = 0;
    foreach (DataGridViewRow row in dgvSale.Rows)
    {
       tab[i] = new Table(); //Or another valid constructor for this class
       tab[i].Stock = row.Cells[0].Value.ToString();
       tab[i].Impure = decimal.Parse(row.Cells[1].Value.ToString());
       tab[i].Pure = decimal.Parse(row.Cells[2].Value.ToString());
       tab[i].Labor = int.Parse(row.Cells[3].Value.ToString());
       i++;
    }
