    public enum SystemState
    {
        /// <summary>
        /// System is under the control of a remote logging application.  
        /// </summary>
        RemoteMode,
        /// <summary>
        /// System is not under the control of a remote logging application.
        /// </summary>
        LocalMode
    }
    public interface IView
    {
        void SetState(SystemState state);
    }
    //method on the UI to modify UI
        private void SetState(SystemState state)
        {
            switch (state)
            {
                case SystemState.LocalMode:
                    //for now, just unlock the ui
                    break;
                case SystemState.RemoteMode:
                    //for now, just lock the ui
                    break;
                default:
                    throw new Exception("Unknown State requested:" + state);
            }
        }
        //now when you change state, you can take advantage of intellisense and compile time checking:
        public void Connect()
        {
                SetState(SystemState.RemoteMode);
        }
