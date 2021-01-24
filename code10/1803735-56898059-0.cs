    protected override void Initialize ()
    {
      YourExtension.Initialize (this);
      base.Initialize ();
      YourExtension.Instance.DTEObject = (EnvDTE.DTE)base.GetService (typeof (Microsoft.VisualStudio.Shell.Interop.SDTE));
    }
