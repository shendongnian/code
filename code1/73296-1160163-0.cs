    public static class ControlExtensions {
        public static List<T> FindControlsByInterface<T>(this Control control) where T : class
        {
            List<T> retval = new List<T>();
            T item = control as T;
            if (T != null)
                retval.Add(item);
    
            foreach (Control c in control.Controls)
                retval.AddRange(c.FindControlsByInterface<T>());
    
            return retval;
        }
    }
