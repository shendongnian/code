     <ListBox HorizontalAlignment="Left" Height="100" Margin="80,125,0,0" VerticalAlignment="Top" Width="100" Drop="ListBox_Drop" AllowDrop="True"  PreviewMouseLeftButtonDown="ListBox_MouseLeftButtonDown">
            <ListBoxItem >item1</ListBoxItem>                                                                                                          
            <ListBoxItem >item2</ListBoxItem>                                                                                                          
            <ListBoxItem >item3</ListBoxItem>                                                                                                          
            <ListBoxItem >item4</ListBoxItem>
        </ListBox>
        <ListBox HorizontalAlignment="Left" Height="100" Margin="200,125,0,0" VerticalAlignment="Top" Width="100" Drop="ListBox_Drop" AllowDrop="True"/>
    ListBox dragSource;
        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            ListBox item = (ListBox)sender;
            object data = e.Data.GetData(typeof(ListBoxItem));
            dragSource.Items.Remove(data);
            item.Items.Add(data);
        }
        private void ListBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox source = (ListBox)sender;
            dragSource = source;
            object item= GetDataFromListBox(dragSource, e.GetPosition(source));
            if (item != null)
            {
                DragDrop.DoDragDrop(source, item, DragDropEffects.Move);
            }
        }
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }
