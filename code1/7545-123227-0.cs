    if (listBox.ItemsSource.IsGenericType && 
        typeof(IDictionary<,>).IsAssignableFrom(listBox.ItemsSource.GetGenericTypeDefinition()))
    {
        var method = typeof(KeyValuePair<,>).GetProperty("Value").GetGetMethod();
        var item = method.Invoke(listBox.SelectedItem, null);
    }
