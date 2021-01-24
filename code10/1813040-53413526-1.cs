                var points = new MeasurePoint[Y.Count - 1];
            for (int i = 0; i < Y.Count; i++)
            {
                points[i] = new MeasurePoint(DateTimeAxis.ToDouble(X[i]), Y[i], Y[i]*scale);
            }
            Series.ItemsSource = points;
            Series.TrackerFormatString = "{0}\n{2}\n{Scale}";
