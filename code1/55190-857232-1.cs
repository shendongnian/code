    private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0)
        {
            return;
        }
        Template template = comboBox1.Items[e.Index] as Template;
        if (template != null)
        {
    
            Font font = comboBox1.Font;
            Brush backgroundColor;
            Brush textColor;
    
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = SystemBrushes.Highlight;
                textColor = SystemBrushes.HighlightText;
            }
            else
            {
                backgroundColor = SystemBrushes.Window;
                textColor = SystemBrushes.WindowText;
            }
            if (template.IsDefault)
            {
                font = new Font(font, FontStyle.Bold);
            }
            e.Graphics.FillRectangle(backgroundColor, e.Bounds);
            e.Graphics.DrawString(template.Name, font, textColor, e.Bounds);
    
        }
    }
