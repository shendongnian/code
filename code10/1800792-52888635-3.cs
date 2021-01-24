    public class SendConfirmationEmail : Listener<UserWasUpdated>, IHandleSuccess
    {
        private _Event = null;
        public override void Handle(UserWasUpdated _event)
        {
            // Store _event
            _Event = _event;
        }
        public void Finished()
        {
            // Call whatever function on your object
            this.Cleanup()
            // Call whatever is needed on _event
            _Event?.Cleanup();
        }
    }
