            public bool Equals(SolidColorBrush brush1, SolidColorBrush brush2) {
            return brush1.Opacity == brush2.Opacity &&
                brush1.Color.A == brush2.Color.A &&
                brush1.Color.R == brush2.Color.R &&
                brush1.Color.B == brush2.Color.B &&
                brush1.Color.G == brush2.Color.G;
        }
