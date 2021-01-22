    public void TraverseHierarchy(ControlCollection controls)
    {
        foreach (Control c in controls)
        {
            CheckBox checkBox = c as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.ID.StartsWith("cb"))
                {
                    checkBoxes.Add(checkBox);
                }
            }
            if (c.Controls.Count > 0)
            {
                TraverseHierarchy(c.Controls);
            }
        }
    }
