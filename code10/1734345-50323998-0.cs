        public void FindPosition(object obj)
        {
            if (obj == null) return;
            var plotView = (PlotView)obj;
            FindTextPosition<PlotView>(plotView).FindName(plotView.Name);
        }
        private IEnumerable<T> FindTextPosition<T>(DependencyObject parent)
            where T : DependencyObject
        {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is TextBlock text)
                {
                    if (text.Text == "Test") // Or any identifier you could specify
                    {
                        var position = text.PointToScreen(new Point(0d, 0d));
                            
                    }
                   
                }
                foreach (var other in FindTextPosition<T>(child)) yield return other;
            }
        }
