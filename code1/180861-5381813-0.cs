        private void YourMethodForDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Type sourceType = e.OriginalSource.GetType();
            if (sourceType != typeof(System.Windows.Controls.TextBlock)
                && sourceType != typeof(System.Windows.Controls.Border))
                return;
            //if you get here, it's one of the list items.
            DoStuff();
            ...
        }
