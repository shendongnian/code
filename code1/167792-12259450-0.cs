    object[,] Values = new object[iGrid.Rows.Count, IGrid.Columns.Count];
                for (int i = 0; i < alllogentry.Rows.Count; i++)
                {
                    for (int j = 0; j < alllogentry.Columns.Count; j++)
                    {
                        if (alllogentry.Rows[i].Cells[j].Value != null)
                        {
                            Values[i, j] = alllogentry.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            Values[i, j] = " ";
                        }
                    }
                }
