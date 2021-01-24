    private void Button_Click(object sender, RoutedEventArgs e)
    {
        UIHelper.UpdateDataBindings<Control>(this);
        
        foreach(var item in Items)
        {
            item.UpdateState();
        }
    }
