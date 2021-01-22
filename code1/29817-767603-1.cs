    using System.Reflection;
    using System.Windows.Forms;
    bool addScrollListener(DataGridView dgv)
    {
        bool ret = false;
        Type t = dgv.GetType();
        PropertyInfo pi = t.GetProperty("VerticalScrollBar", BindingFlags.Instance | BindingFlags.NonPublic);
        ScrollBar s = null;
        if (pi != null)
            s = pi.GetValue(dgv, null) as ScrollBar;
        if (s != null)
        {
            s.Scroll += new ScrollEventHandler(s_Scroll);
            ret = true;
        }
    
        return ret;
    }
    void s_Scroll(object sender, ScrollEventArgs e)
    {
        // Hander goes here..
    }
    
