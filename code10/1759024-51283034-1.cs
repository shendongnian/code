    /// <summary>
    /// Finds a parent of a given item on the visual tree.
    /// </summary>
    /// <typeparam name="T">The type of the queried item.</typeparam>
    /// <param name="child">A direct or indirect child of the
    /// queried item.</param>
    /// <returns>The first parent item that matches the submitted
    /// type parameter. If not matching item can be found, a null
    /// reference is being returned.</returns>
    public static T TryFindParent<T>(this DependencyObject child) where T : DependencyObject
    {
        //get parent item
        DependencyObject parentObject = GetParentObject(child);
        //we've reached the end of the tree
        if (parentObject == null) return null;
        //check if the parent matches the type we're looking for
        T parent = parentObject as T;
        if (parent != null)
        {
            return parent;
        }
        else
        {
            //use recursion to proceed with next level
            return TryFindParent<T>(parentObject);
        }
    }
