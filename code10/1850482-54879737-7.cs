        private  void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            PositionStoryboard.Begin();
        }
        private void RepositionThemeAnimation_Completed(object sender, object e)
        {
            rectangleItems.Items.Clear();
            for (int i = 0; i < 9; i++)
            {
                rectangleItems.Items.Add(new Rectangle() { Fill = new SolidColorBrush(Colors.Yellow), Width = 100, Height = 100, Margin = new Thickness(10) });
            }
        }
