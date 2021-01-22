     public  string Text2Path()
        {
            FormattedText formattedText = new System.Windows.Media.FormattedText("Any text you like",
                CultureInfo.GetCultureInfo("en-us"),
                  FlowDirection.LeftToRight,
                   new Typeface(
                        new FontFamily(),
                        FontStyles.Italic,
                        FontWeights.Bold,
                        FontStretches.Normal),
                        16, Brushes.Black);
            Geometry geometry = formattedText.BuildGeometry(new Point(0, 0));
            System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
            path.Data = geometry;
            string geometryAsString = geometry.GetFlattenedPathGeometry().ToString().Replace(",",".").Replace(";",",");
            return geometryAsString;
        }
