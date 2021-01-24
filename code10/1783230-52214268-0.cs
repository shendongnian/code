    /// <summary>
        /// Return the element used to display the given item
        /// </summary>
        DependencyObject IGeneratorHost.GetContainerForItem(object item)
        {
            DependencyObject container;
 
            // use the item directly, if possible (bug 870672)
            if (IsItemItsOwnContainerOverride(item))
                container = item as DependencyObject;
            else
                container = GetContainerForItemOverride();
 
            // the container might have a parent from a previous
            // generation (bug 873118).  If so, clean it up before using it again.
            //
            // Note: This assumes the container is about to be added to a new parent,
            // according to the ItemsControl/Generator/Container pattern.
            // If someone calls the generator and doesn't add the container to
            // a visual parent, unexpected things might happen.
            Visual visual = container as Visual;
            if (visual != null)
            {
                Visual parent = VisualTreeHelper.GetParent(visual) as Visual;
                if (parent != null)
                {
                    Invariant.Assert(parent is FrameworkElement, SR.Get(SRID.ItemsControl_ParentNotFrameworkElement));
                    Panel p = parent as Panel;
                    if (p != null && (visual is UIElement))
                    {
                        p.Children.RemoveNoVerify((UIElement)visual);
                    }
                    else
                    {
                        ((FrameworkElement)parent).TemplateChild = null;
                    }
                }
            }
 
            return container;
        }
