    private void grpImmunizationCntrl_Paint(object sender, PaintEventArgs e)
    {
        if (lkuNOImmunizationReason.Text.Equals(string.Empty)
        {
           ControlPaint.DrawBorder(
                    e.Graphics, new Rectangle(lkuNOImmunizationReason.Left, lkuNOImmunizationReason.Top, lkuNOImmunizationReason.ClientRectangle.Width, lkuNOImmunizationReason.ClientRectangle.Height),
                        Color.Firebrick, ButtonBorderStyle.Solid);
        }
    }
