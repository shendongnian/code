    private void clearCollection(Control.ControlCollection target)
    {
        foreach (Control Actrl in target)
        {
            if (Actrl is Label || Actrl is Button)
            {
                target.Remove(Actrl);
            }
        }
     }
