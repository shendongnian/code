            DataGridViewSelectedRowCollection dtSeleccionados = dataGrid.SelectedRows;
            DataGridViewCellCollection dtCells;
            String row;
            String strCopiado = "";
            for (int i = dtSeleccionados.Count - 1; i >= 0; i--)
            {
                dtCells = dtSeleccionados[i].Cells;
                row = "";
                for (int j = 0; j < dtCells.Count; j++)
                {
                    row = row + dtCells[j].Value.ToString() + (((j + 1) == dtCells.Count) ? "" : "\t");
                }
                strCopiado = strCopiado + row + "\n";
            }
            try
            {
                Clipboard.SetText(strCopiado);
            }
            catch (ArgumentNullException ex)
            {
                Console.Write(ex.ToString());
            }
