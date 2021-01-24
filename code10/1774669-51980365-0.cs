    private void ImgDistry_Click(object sender, RoutedEventArgs e)
        {
            image.Source = null;
            UpdateLayout();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
