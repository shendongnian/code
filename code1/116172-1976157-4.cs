    public class EmailDispatcherBase: IEmailDispatcher {
        // cheating on the arguments here to save space
        public void SendEmail(object[] args) {
            try {
                // basic implementation here
                this.OnEmailSent();
            }
            catch {
                this.OnEmailFailed();
                throw;
            }
        }
        protected virtual  void OnEmailSent() {}
        protected virtual  void OnEmailFailed() {}
    }
