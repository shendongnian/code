    public class SendConfirmationEmail : Listener<UserWasUpdated>, IHandleSuccess<UserWasUpdated>
    {
        public override void Handle(UserWasUpdated _event)
        {
            // ...
        }
        public void Finished(UserWasUpdated _event)
        {
            // Call whatever function on your object
            this.Cleanup()
        }
    }
