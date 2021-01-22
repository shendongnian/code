    class UserResetScope : IDisposable {
        private IPrincipal originalUser;
        public UserResetScope(string newUserName) {
            originalUser = Thread.CurrentPrincipal;
            var newUser = new GenericPrincipal(new GenericIdentity(newUserName), new string[0]);
            Thread.CurrentPrincipal = newUser;
        }
        public IPrincipal OriginalUser { get { return this.originalUser; } }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                Thread.CurrentPrincipal = originalUser;
            }
        }
    }
