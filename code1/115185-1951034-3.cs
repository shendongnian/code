    public static class ControlExtensions
    {
        public static void FindControlByType<TControl>(this Control container, ref List<TControl> controls) where TControl : Control
        {
            if (container == null)
                throw new ArgumentNullException("container");
            if (controls == null)
                throw new ArgumentNullException("controls");
            foreach (Control ctl in container.Controls)
            {
                if (ctl is TControl)
                    controls.Add((TControl)ctl);
                ctl.FindControlByType<TControl>(ref controls);
            }
        }
    }
