    protected virtual void OnChangeCulture(CultureInfo newCulture)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
        System.Threading.Thread.CurrentThread.CurrentUICulture = newCulture;
    
        SuspendLayout();
        this.ApplyResources(); // <--
        ResumeLayout(true);
    }
