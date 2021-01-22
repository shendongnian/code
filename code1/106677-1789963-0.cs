    public static T FindControlRecursive<T>(this Control parentControl, string id) where T : Control
        {
            T ctrl = default(T);
            if ((parentControl is T) && (parentControl.ID == id))
                return (T)parentControl;
            foreach (Control c in parentControl.Controls)
            {
                ctrl = c.FindControlRecursive<T>(id);
                if (ctrl != null)
                    break;
            }
            return ctrl;
        }
    // and then: Page.FindControlRecursive<CheckBox>(idOfYourControl);
