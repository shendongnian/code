    static DefaultFormInfo FormInfo = new DefaultFormInfo();
    void FillDefaults()
    {
                foreach (PropertyInfo pinf in FormInfo.GetType().GetProperties())
                {
                    pinf.SetValue(FormInfo, this.GetType().GetProperty(pinf.Name).GetValue(this, null), null);
                }
    }
    void Restore()
    {
        foreach (PropertyInfo pinf in FormInfo.GetType().GetProperties())
        {
            this.GetType().GetProperty(pinf.Name).SetValue(this, pinf.GetValue(FormInfo, null), null);
        }
    }
