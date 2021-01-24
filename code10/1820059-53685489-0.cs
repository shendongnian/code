            Brush a = rect.Fill;
            Color color = ((SolidColorBrush)a).Color;
            string selectedcolorname;
            foreach (var colorvalue in typeof(Colors).GetRuntimeProperties())
            {
                if ((Color)colorvalue.GetValue(null) == color)
                {
                    selectedcolorname = colorvalue.Name;
                }
            }
