    public void End()
    {
      if (this._context.IsInCancellablePeriod) {
        InternalSecurityPermissions.ControlThread.Assert();
        Thread.CurrentThread.Abort(new HttpApplication.CancelModuleException(false));
      }
      else if (!this._flushing)
      {
        this.Flush();
        this._ended = true;
        if (this._context.ApplicationInstance != null) {
          this._context.ApplicationInstance.CompleteRequest();
        }
      }
    }
