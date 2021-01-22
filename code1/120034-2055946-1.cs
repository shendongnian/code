    public static IEnumerable<Control> GetDeepControlsByType<T>(this Control control)
    {
        foreach(Control c in control.Controls)
        {
            if (c is T)
            {
                yield return c;
            }
    
            if(c.Controls.Count > 0)
            {
                foreach (Control control in c.GetDeepControlsByType<T>())
                {
                    yield return control;
                }
            }
        }
    }
