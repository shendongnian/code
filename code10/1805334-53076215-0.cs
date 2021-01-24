        //List to store all the elements under the cursor
        private List<DependencyObject> hitResultsList = new List<DependencyObject>();
        private void HandleMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            Point pt = e.GetPosition((UIElement)sender);
            hitResultsList.Clear();
            //Retrieving all the elements under the cursor
            VisualTreeHelper.HitTest(this, null,
                new HitTestResultCallback(MyHitTestResult),
                new PointHitTestParameters(pt));
            //Testing if the grdFilters is under the cursor
            if (!hitResultsList.Contains(this.grdFilters) && grdFilters.Visibility == System.Windows.Visibility.Visible)
            {
                grdFilters.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        //Necessary callback function
        private HitTestResultBehavior MyHitTestResult(HitTestResult result)
        {
            hitResultsList.Add(result.VisualHit);
            return HitTestResultBehavior.Continue;
        }
