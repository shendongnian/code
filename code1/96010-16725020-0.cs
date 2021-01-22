    /// <summary> Return all of the children in the hierarchy of the control. </summary>
    /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
    /// <param name="control"> The control that serves as the root of the hierarchy. </param>
    /// <param name="maxDepth"> (optional) The maximum number of levels to iterate.  Zero would be no
    ///  controls, 1 would be just the children of the control, 2 would include the children of the
    ///  children. </param>
    /// <returns>
    ///  An enumerator that allows foreach to be used to process iterate all children in this
    ///  hierarchy.
    /// </returns>
    public static IEnumerable<Control> IterateAllChildren(this Control control,
                                                          int maxDepth = int.MaxValue)
    {
      if (control == null)
        throw new ArgumentNullException("control");
      if (maxDepth == 0)
        return new Control[0];
      return IterateAllChildrenSafe(control, 1, maxDepth);
    }
    private static IEnumerable<Control> IterateAllChildrenSafe(Control rootControl,
                                                               int depth,
                                                               int maxDepth)
    {
      foreach (Control control in rootControl.Controls)
      {
        yield return control;
        // only iterate children if we're not too far deep and if we 
        // actually have children
        if (depth >= maxDepth || control.Controls.Count == 0)
          continue;
        var children = IterateAllChildrenSafe(control, depth + 1, maxDepth);
        foreach (Control subChildControl in children)
        {
          yield return subChildControl;
        }
      }
    }
