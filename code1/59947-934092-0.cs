    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      // dlg is a variable of type Form2(the dialog)
      if (dlg != null)
      {
        dlg.Dispose();
        dlg = null;
      }
      base.Dispose(disposing);
    }
