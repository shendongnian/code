            var yourColor = System.Drawing.Color.Blue;
            if ((x.Background as SolidColorBrush).Color.A == yourColor.A &&
                (x.Background as SolidColorBrush).Color.R == yourColor.R &&
                (x.Background as SolidColorBrush).Color.G == yourColor.G &&
                (x.Background as SolidColorBrush).Color.B == yourColor.B)
            {
                //do something nice here
            }
