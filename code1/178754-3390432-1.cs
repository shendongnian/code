        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = FilterTextBox.Text;
            var source = MyList.Items as ICollectionView;
            if (string.IsNullOrWhiteSpace(filter))
            {
                source.Filter = null;
            }
            else
            {
                source.Filter = delegate(object item)
                {
                    var s = item as INamedItem;
                    return s.Name.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) != -1;
                };
            }
        }
