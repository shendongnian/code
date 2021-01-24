        public event SelectionChangedEventHandler SelectionChanged;
        ...
        listBox.SelectionChanged += listBox_SelectionChanged;
        ...
        void listBox_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            SelectionChanged?.Invoke(sender, args);
        }
