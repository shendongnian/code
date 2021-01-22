    private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
            {
                if (e.Index == -1)
                    return;
                ComboBox combo = ((ComboBox)sender);
                using (SolidBrush brush = new SolidBrush(e.ForeColor))
                {
                    Font font = e.Font;
                    if (/*Condition Specifying That Text Must Be Bold*/)
                        font = new System.Drawing.Font(font, FontStyle.Bold);
                    e.DrawBackground();
                    e.Graphics.DrawString(combo.Items[e.Index].ToString(), font, brush, e.Bounds);
                    e.DrawFocusRectangle();
                }
    
            }
