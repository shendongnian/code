    public static class ControlExtensions
    {
        public static T Clone<T>(this T controlToClone)  where T : Control
        {
            PropertyInfo[] controlProperties = 
              typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //T instance = Activator.CreateInstance<T>();
            Control instance = (Control) Activator.CreateInstance(controlToClone.GetType());
            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance,
                                          propInfo.GetValue(controlToClone, null), null);
                }
            }
            foreach(Control ctl in controlToClone.Controls)
            {
                instance.Controls.Add( ctl.Clone() );
            }
            return (T) instance;
        }
    }
