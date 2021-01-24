        public ExtendedCanvas()
        {
            Loaded += ExtendedCanvas_Loaded;
        }
        private void ExtendedCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            _containingScrollViewer  = Parent as ScrollViewer;
        }
