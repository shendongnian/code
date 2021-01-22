    public static void ShowWithParentFormLock(this Form childForm, Form parentForm)
    {
      childForm.ShowWithParentFormLock(parentForm, null);
    }
    public static void ShowWithParentFormLock(this Form childForm, Form parentForm, Action actionAfterClose)
    {
      if (childForm == null)
        throw new ArgumentNullException("childForm");
      if (parentForm == null)
        throw new ArgumentNullException("parentForm");
      EventHandler activatedDelegate = (object sender, EventArgs e) =>
      {
        childForm.Focus();
        //To Do: Add ability to flash form to notify user that focus changed
      };
      childForm.FormClosed += (sender, closedEventArgs) =>
        {
          try
          {
            parentForm.Focus();
            if(actionAfterClose != null)
              actionAfterClose();
          }
          finally
          {
            try
            {
              parentForm.Activated -= activatedDelegate;
              if (!childForm.IsDisposed || !childForm.Disposing)
                childForm.Dispose();
            }
            catch { }
          }
        };
      parentForm.Activated += activatedDelegate;
      childForm.Show(parentForm);
    }
