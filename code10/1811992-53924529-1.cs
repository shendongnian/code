    private object FindFocusable(int startIndex, int direction, out int foundIndex, out FrameworkElement foundContainer)
    {
        // HasItems may be wrong when underlying collection does not notify, but this function
        // only cares about what's been generated and is consistent with ItemsControl state.
        if (HasItems)
        {
            int count = Items.Count;
            for (; startIndex >= 0 && startIndex < count; startIndex += direction)
            {
                FrameworkElement container = ItemContainerGenerator.ContainerFromIndex(startIndex) as FrameworkElement;
                // If the UI is non-null it must meet some minimum requirements to consider it for
                // navigation (focusable, enabled).  If it has no UI we can make no judgements about it
                // at this time, so it is navigable.
                if (container == null || Keyboard.IsFocusable(container))
                {
                    foundIndex = startIndex;
                    foundContainer = container;
                    return Items[startIndex];
                }
            }
        }
        foundIndex = -1;
        foundContainer = null;
        return null;
    }
