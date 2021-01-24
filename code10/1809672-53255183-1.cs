       int s=0;
    List<ListBox> allControls = new List<ListBox>();
            GetControlList<ListBox>(Page.Controls, allControls);
    foreach (var childControl in allControls)
            {
                s +=  Int32.Parse( childControl.SelectedValue);
            }
