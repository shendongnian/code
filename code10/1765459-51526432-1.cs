                for (int i = (_GridCell.Count() - 1); i >= 0; i--)
                {
                    if (_GridCell[i].Value != null)
                    {
                        e.Graphics.DrawString(_GridCell[i].FormattedValue.ToString(),
                            _GridCell[i].InheritedStyle.Font,
                            new SolidBrush(_GridCell[i].InheritedStyle.ForeColor),
                            new RectangleF((int)arrColumnLefts[i],
                            (float)iTopMargin,
                            (int)arrColumnWidths[i], (float)iCellHeight),
                            strFormat);
                    }
                    //Drawing Cells Borders 
                    e.Graphics.DrawRectangle(Pens.Black,
                        new Rectangle((int)arrColumnLefts[i], iTopMargin,
                        (int)arrColumnWidths[i], iCellHeight));
                }
