    int hoveredIndex = -1;
    private void lstCars_MouseMove(object sender, MouseEventArgs e)
    {
        int newHoveredIndex = lstCars.IndexFromPoint(e.Location);
 
        if (hoveredIndex != newHoveredIndex)
        {
            hoveredIndex = newHoveredIndex;
            if (hoveredIndex > -1)
            {
                tt1.Active = false;
                tt1.SetToolTip(lstCars, ((Car)lstCars.Items[hoveredIndex]).InsuranceGroup);
                tt1.Active = true;
            }
        }
    }
