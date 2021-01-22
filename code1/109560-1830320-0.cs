    private void listBox1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        object item = GetElementFromPoint(listBox1, e.GetPosition(listBox1));
        if (item!=null)
            Console.WriteLine(item);
        else
            Console.WriteLine("no item found");
    }
    
    private object GetElementFromPoint(ItemsControl itemsControl, Point point)
    {
        // you can use either VisualTreeHelper.HitTest or itemsControl.InputHitTest method here; both of them would work
        //UIElement element = VisualTreeHelper.HitTest(itemsControl, point).VisualHit as UIElement;
        UIElement element = itemsControl.InputHitTest(point) as UIElement;
        while (element!=null)
        {
            if (element == itemsControl)
                return null;
            object item = itemsControl.ItemContainerGenerator.ItemFromContainer(element);
            if (!item.Equals(DependencyProperty.UnsetValue))
                return item;
            element = (UIElement)VisualTreeHelper.GetParent(element);
        }
        return null;
    }
