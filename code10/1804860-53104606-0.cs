     public class AuthListener : Java.Lang.Object, IOnSuccessListener, IOnFailureListener
    {
        public delegate void OnAuthFailure(string error);
        public event OnAuthFailure OnAuthFailureEvent;
        public delegate void OnAuthSuccess();
        public event OnAuthSuccess OnAuthSuccessEvent;
        public AuthListener()
        {
        }
        public void OnSuccess(Java.Lang.Object result)
        {
            Console.WriteLine("success");
            OnAuthSuccessEvent?.Invoke();
        }
        public void OnFailure(Java.Lang.Exception e)
        {
            Console.WriteLine("failure: " + e.Message);
            OnAuthFailureEvent?.Invoke(e.Message);
        }
    }
