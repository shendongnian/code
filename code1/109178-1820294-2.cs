    IList<Control> controlsOnForm = new List<Control>();
    BuildControlsList(this.Controls, controlsOnForm);
    private static void BuildControlsList(ControlCollection controls, IList<Control> listToPopulate)
    {
        foreach (Control childControl in controls)
        {
            listToPopulate.Add(childControl);
            BuildControlsList(childControl.Controls, listToPopulate);
        }
    }
