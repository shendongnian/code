    static class ExtensionMethods
    {
    public void DoubleBuffered(DataGridView dgv, bool setting)
    {
        Type dgvType = dgv.GetType();
        PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        pi.SetValue(dgv, setting, null);
    }
    }
      ExtensionMethods.DoubleBuffered(mydgvw, True);
