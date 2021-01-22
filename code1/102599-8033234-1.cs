    private void PasteClipboard()
            {
                try
                {
                    string s = Clipboard.GetText();
                    string[] lines = s.Split('\n');
                    int iFail = 0, iRow = dgData.CurrentCell.RowIndex;
                    int iCol = dgData.CurrentCell.ColumnIndex;
                    DataGridViewCell oCell;
                    if (dgData.Rows.Count < lines.Length)
                        dgData.Rows.Add(lines.Length-1);
                    foreach (string line in lines)
                    {
                        if (iRow < dgData.RowCount && line.Length > 0)
                        {
                            string[] sCells = line.Split('\t');
                            for (int i = 0; i < sCells.GetLength(0); ++i)
                            {
                                if (iCol + i < this.dgData.ColumnCount)
                                {
                                    oCell = dgData[iCol + i, iRow];
                                    if (!oCell.ReadOnly)
                                    {
                                        if (oCell.Value==null|| oCell.Value.ToString() != sCells[i])
                                        {
                                            oCell.Value = Convert.ChangeType(sCells[i],
                                                                  oCell.ValueType);
                                          //  oCell.Style.BackColor = Color.Tomato;
                                        }
                                        else
                                            iFail++;
                                        //only traps a fail if the data has changed 
                                        //and you are pasting into a read only cell
                                    }
                                }
                                else
                                { break; }
                            }
                            iRow++;
                        }
                        else
                        { break; }
                        if (iFail > 0)
                            MessageBox.Show(string.Format("{0} updates failed due" +
                                            " to read only column setting", iFail));
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("The data you pasted is in the wrong format for the cell");
                    return;
                }
            }
