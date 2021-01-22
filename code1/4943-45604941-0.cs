    public static void DoubleBuffered(this DataGridView datagridview, bool setting)
    {
        Type DgvType = datagridview.GetType();
        PropertyInfo pi = DgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        pi.SetValue(datagridview, setting, null);
    }
