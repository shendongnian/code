    private void deal_details_panel_Paint(object sender, PaintEventArgs e)
    {
        if(_drawBorder)
        {
            int thickness = 2;//it's up to you
            int halfThickness = thickness / 2;
            using (Pen p = new Pen(Color.GreenYellow, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                          halfThickness,
                                                          deal_details_panel.ClientSize.Width - thickness,
                                                          deal_details_panel.ClientSize.Height - thickness));
            }
        }
    }
