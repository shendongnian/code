    private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGridView1?.CurrentCell?.OwningColumn?.Name != "CategoryIdColumn")
            return;
        var combo = e.Control as DataGridViewComboBoxEditingControl;
        if (combo == null)
            return;
        combo.DrawMode = DrawMode.OwnerDrawFixed;
        combo.DrawItem += (obj, args) =>
        {
            var txt = args.Index >= 0 ? combo.GetItemText(combo.Items[args.Index]) : "";
            var textColor = args.Index == 0 ? SystemColors.GrayText : SystemColors.ControlText;
            var font = args.Index == 0 ? new Font(combo.Font, FontStyle.Italic) : combo.Font;
            if ((args.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                textColor = SystemColors.HighlightText;
            }
            args.DrawBackground();
            TextRenderer.DrawText(args.Graphics, txt, font,
                args.Bounds, textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        };
    }
