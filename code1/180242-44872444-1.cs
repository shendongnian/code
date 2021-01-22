    public static IEnumerable<TControl> FindChildControlsOfType<TControl>(this Control control) where TControl : Control
        {
            foreach (var childControl in control.Controls.Cast<Control>())
            {
                if (childControl.GetType() == typeof(TControl))
                {
                    yield return (TControl)childControl;
                }
                else
                {
                    foreach (var next in FindChildControlsOfType<TControl>(childControl))
                    {
                        yield return next;
                    }
                }
            }
        }
