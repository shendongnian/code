            Row row = rows.FirstOrDefault<Row>();
            row.Remove();
            string cr;
            foreach ( Row rowElement in rows )
            {
                rowElement.RowIndex.Value -= 1;
                IEnumerable<Cell> cells = rowElement.Elements<Cell>().ToList();
                if ( cells != null )
                {
                    foreach ( Cell cell in cells )
                    {
                        cr = cell.CellReference.Value;
                        int indexRow = Convert.ToInt32( Regex.Replace( cr, @"[^\d]+", "" ) ) - 1;
                        cr = Regex.Replace( cr, @"[\d-]", "" );
                        cell.CellReference.Value = $"{cr}{indexRow}";
                    }
                }
            }
