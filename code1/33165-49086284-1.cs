    string columnNew = new String(cellReference.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
                foreach (Cell cell in row.Elements<Cell>())
                {
                    string columnBase = new String(cell.CellReference.Value.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
                    if (ColumnIndex(columnBase) > ColumnIndex(columnNew))
                    {
                        refCell = cell;
                        break;
                    }
                }
