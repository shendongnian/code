    private void ResizeDescriptionArea(PropertyGrid grid, int lines)
    {
        try
        {
            var info = grid.GetType().GetProperty("Controls");
            var collection = (Control.ControlCollection)info.GetValue(grid, null);
            foreach (var control in collection)
            {
                var type = control.GetType();
                if ("DocComment" == type.Name)
                {
                    const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;
                    var field = type.BaseType.GetField("userSized", Flags);
                    field.SetValue(control, true);
                    info = type.GetProperty("Lines");
                    info.SetValue(control, lines, null);
                    grid.HelpVisible = true;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex);
        }
    }
