    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e) {
      Color textColor = SystemColors.WindowText;
      if (e.Item.Selected) {
        if (listView1.Focused) {
          textColor = SystemColors.HighlightText;
          e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
        } else if (!listView1.HideSelection) {
          textColor = SystemColors.ControlText;
          e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);
        }
      } else {
        using (SolidBrush br = new SolidBrush(listView1.BackColor)) {
          e.Graphics.FillRectangle(br, e.Bounds);
        }
      }
      e.Graphics.DrawRectangle(Pens.Red, e.Bounds);
      TextRenderer.DrawText(e.Graphics, e.Item.Text, listView1.Font, e.Bounds,
                            textColor, Color.Empty,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
