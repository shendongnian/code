    public class FormHelper
    {
        public void CodeIWantToRunIn2Places()
        {
           // Implementation Here
        }
    }
You can implement the above as a singleton so you have access in both places.  Then in your form classes you could do:
    FormHelper.Instance.CodeIWantToRunIn2Places();
In your event handler as well as in your user control.
