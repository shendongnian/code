        public ExtendedCanvas()
        {
            //it hasn't been added to its parent yet
            Loaded += ExtendedCanvas_Loaded;
        }
        private void ExtendedCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            //now it is added to its parent
            _containingScrollViewer  = Parent as ScrollViewer;
        }
