                for (int i = (_GridCell.Count() - 1); i >= 0; i--) // i goes from count - 1 to 0
                {
                    if (_GridCell[i].Value != null)
                    {
                        e.Graphics.DrawString(_GridCell[i].FormattedValue.ToString(),
                            _GridCell[i].InheritedStyle.Font,
                            new SolidBrush(_GridCell[i].InheritedStyle.ForeColor),
                            new RectangleF((int)arrColumnLefts[iCount],
                            (float)iTopMargin,
                            (int)arrColumnWidths[iCount], (float)iCellHeight),
                            strFormat);
                    }
                    //Drawing Cells Borders 
                    e.Graphics.DrawRectangle(Pens.Black,
                        new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                        (int)arrColumnWidths[iCount], iCellHeight));
                    iCount++; //iCount goes from 0 to count - 1
                }
