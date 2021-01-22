    public static void FlattenAndAppend(this System.Windows.Forms.Control.ControlCollection collection, System.Windows.Forms.Control.ControlCollection newCollection)
    {
        List<Control> controlList = new List<Control>();
        FlattenControlTree(collection, controlList);
        newCollection.AddRange(controlList.ToArray());
    }
    public static void FlattenControlTree(System.Windows.Forms.Control.ControlCollection collection, List<Control> controlList)
    {
        foreach (Control control in collection)
        {
            controlList.Add(control);
            FlattenControlTree(control.Controls, controlList);
        }
    }
