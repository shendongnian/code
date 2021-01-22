    public Control[] Find(string key, bool searchAllChildren)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException("key", SR.GetString("FindKeyMayNotBeEmptyOrNull"));
        }
        ArrayList list = this.FindInternal(key, searchAllChildren, this, new ArrayList());
        Control[] array = new Control[list.Count];
        list.CopyTo(array, 0);
        return array;
    }
    private ArrayList FindInternal(string key, bool searchAllChildren, Control.ControlCollection controlsToLookIn, ArrayList foundControls)
    {
        if ((controlsToLookIn == null) || (foundControls == null))
        {
            return null;
        }
        try
        {
            for (int i = 0; i < controlsToLookIn.Count; i++)
            {
                if ((controlsToLookIn[i] != null) && WindowsFormsUtils.SafeCompareStrings(controlsToLookIn[i].Name, key, true))
                {
                    foundControls.Add(controlsToLookIn[i]);
                }
            }
            if (!searchAllChildren)
            {
                return foundControls;
            }
            for (int j = 0; j < controlsToLookIn.Count; j++)
            {
                if (((controlsToLookIn[j] != null) && (controlsToLookIn[j].Controls != null)) && (controlsToLookIn[j].Controls.Count > 0))
                {
                    foundControls = this.FindInternal(key, searchAllChildren, controlsToLookIn[j].Controls, foundControls);
                }
            }
        }
        catch (Exception exception)
        {
            if (ClientUtils.IsSecurityOrCriticalException(exception))
            {
                throw;
            }
        }
        return foundControls;
    }
 
