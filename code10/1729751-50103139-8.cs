    // These could be properties used to customize the ComboBox appearance
    Color cboForeColor = Color.Black;
    Color cboBackColor = Color.WhiteSmoke;
    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0) return;
        Color foreColor = e.ForeColor;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        if (e.State.HasFlag(DrawItemState.Focus) && !e.State.HasFlag(DrawItemState.ComboBoxEdit)) {
            e.DrawBackground();
            e.DrawFocusRectangle();
        }
        else {
            using (Brush backgbrush = new SolidBrush(cboBackColor)) {
                e.Graphics.FillRectangle(backgbrush, e.Bounds);
                foreColor = cboForeColor;
            }
        }
        using (Brush textbrush = new SolidBrush(foreColor)) {
            e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(),
                                  e.Font, textbrush, e.Bounds.Height + 10, e.Bounds.Y,
                                  StringFormat.GenericTypographic);
        }
        e.Graphics.DrawImage(this.imageList1.Images[e.Index],
                             new Rectangle(e.Bounds.Location,
                             new Size(e.Bounds.Height - 2, e.Bounds.Height - 2)));
    }
