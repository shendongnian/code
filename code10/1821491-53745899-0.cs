    private void toolTip1_Popup(object sender, PopupEventArgs e)
    {
        ToolTip tt = (sender as ToolTip);
        string ToolTipText = tt.GetToolTip(e.AssociatedControl);
        TextFormatFlags flags = TextFormatFlags.LeftAndRightPadding | TextFormatFlags.NoClipping |
                                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
        using (Font font = new Font("Arial", 12.0f, FontStyle.Bold))
        {
            e.ToolTipSize = TextRenderer.MeasureText(ToolTipText, font, Size.Empty, flags);
            e.ToolTipSize = new Size(e.ToolTipSize.Width + 10, e.ToolTipSize.Height);
        }
    }
    private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
    {
        DrawToolTip(e);
    }
    private void DrawToolTip(DrawToolTipEventArgs e)
    {
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        using (var sf = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.NoWrap))
        {
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Rectangle ShadowBounds = new Rectangle(new Point(e.Bounds.X + 1, e.Bounds.Y + 1), e.Bounds.Size);
            using (var linearGradientBrush = new LinearGradientBrush(e.Bounds, Color.GreenYellow, Color.MintCream, 45f))
            using (Font font = new Font("Arial", 12.0f, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(linearGradientBrush, e.Bounds);
                e.Graphics.DrawString(e.ToolTipText, font, Brushes.LightGray, ShadowBounds, sf);
                e.Graphics.DrawString(e.ToolTipText, font, Brushes.Black, e.Bounds, sf);
            }
        }
    }
