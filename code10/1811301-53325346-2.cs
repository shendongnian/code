    public Color PointStyleColor
        {
            get
            {
                return Color.FromArgb(SelectedPointStyle.Color.AlphaComponent, SelectedPointStyle.Color.RedComponent, SelectedPointStyle.Color.GreenComponent, SelectedPointStyle.Color.BlueComponent); //Need to convert GeoColor to Color
            }
            set { SelectedPointSyle.Color = value; }//Or whatever conversion needed
        }
