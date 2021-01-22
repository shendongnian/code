    bool HttpApplication.IExecutionStep.IsCancellable {
      get {
        return !(this._application.Context.Handler is IHttpAsyncHandler);
      }
    }
