    public abstract class EmailDispatcherBase: IEmailDispatcher {
        public void SendEmail(object[] args) {
            try {
                this.SendEmailCore();
                this.OnEmailSent();
            }
            catch {
                this.OnEmailFailed();
                throw;
            }
        }
        protected abstract void SendEmailCore();
        protected virtual  void OnEmailSent() {}
        protected virtual  void OnEmailFailed() {}
    }
