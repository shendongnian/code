     private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
                {
                    if (e.Index == -1)
                        return;
                    ComboBox combo = ((ComboBox)sender);
                    using (SolidBrush brush = new SolidBrush(e.ForeColor))
                    {
                        Font font = e.Font;
                        DataRowView item = (DataRowView)combo.Items[e.Index];
                    
                        if (/*Condition Specifying That Text Must Be Bold*/) {
                            font = new System.Drawing.Font(font, FontStyle.Bold);
                        }
                        else {
                            font = new System.Drawing.Font(font, FontStyle.Regular);
                        }                    
                        
                        e.DrawBackground();
                        e.Graphics.DrawString(item.Row.Field<String>("DisplayMember"), font, brush, e.Bounds);
                        e.DrawFocusRectangle();
                    }
        
                }
