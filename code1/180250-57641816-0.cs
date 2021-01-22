    public static class ExtensionMethods
    {
        public static IEnumerable<T> GetAll<T>(this Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => ctrl.GetAll<T>())
                                      .Concat(controls.OfType<T>());
        }
    }
