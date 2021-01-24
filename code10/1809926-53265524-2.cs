    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        var content = (string)cb.Content;
        var book = ((Book)listBoxBooks.SelectedItem);
        bool clicked = cb.IsChecked.Value;
        if (clicked)
            book.AddKeyword(content);
        else
            book.RemoveKeyword(content);
    }
