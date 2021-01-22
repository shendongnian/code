        private System.Drawing.Color WpfBrushToDrawingColor(System.Windows.Media.SolidColorBrush br)
        {
            return System.Drawing.Color.FromArgb(
                br.Color.A,
                br.Color.R,
                br.Color.G,
                br.Color.B);
        }
