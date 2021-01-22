    public void Show(kTextBox source)
    {
        Point control_origin = source.PointToScreen(new Point(0, 0));
        this.Location = new Point(control_origin.X, control_origin.Y);
        base.Show();
    }
