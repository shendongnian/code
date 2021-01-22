    void setZindex(MyLayeredType layeredObj, int index) 
    {
        ContentPresenter sibbling = 
        FindVisualParent<ContentPresenter, ItemsPresenter>(layeredObj);
        if (sibbling != null)
        {
            sibbling.SetValue(Canvas.ZIndexProperty, index);
        }
        else
        {
            layeredObj.SetValue(Canvas.ZIndexProperty, index);
        }
    }
    public static T FindVisualParent<T,C>(this DependencyObject obj)
    where T : DependencyObject
    where C : DependencyObject
    {
        DependencyObject parent = VisualTreeHelper.GetParent(obj);
        while (parent != null)
        {
            T typed = parent as T;
            if (typed != null)
            {
                return typed;
            }
            C ceiling = parent as C;
            if (ceiling != null)
                return null;
            parent = VisualTreeHelper.GetParent(parent);
        }
        return null;
    }
