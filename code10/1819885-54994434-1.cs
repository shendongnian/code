        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in TestGridView.ItemsPanelRoot.Children)
            {
                while (!IsCompositionVisualReady(element))
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(1));
                }
                var slideVisual = ElementCompositionPreview.GetElementVisual(element);
