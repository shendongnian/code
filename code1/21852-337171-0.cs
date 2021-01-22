    private void resizeThreadSafe(int width, int height)
    {
        if (this.form.InvokeRequired)
        {
            this.form.Invoke(new DelegateSize(resizeThreadSafe,
                new object[] { width, height });
            return;
        }
        this.form.Size = new Size(width, height);
        this.form.Location = new Point(0, SystemInformation.MonitorSize // whatever comes next
    }
