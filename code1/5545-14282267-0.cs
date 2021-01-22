    public static class ControlExtentions
    {
        /// <summary>
        /// Turn on or off control double buffering (Dirty hack!)
        /// </summary>
        /// <param name="control">Control to operate</param>
        /// <param name="setting">true to turn on double buffering</param>
        public static void MakeDoubleBuffered(this Control control, bool setting)
        {
            Type controlType = control.GetType();
            PropertyInfo pi = controlType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(control, setting, null);
        }
    }
