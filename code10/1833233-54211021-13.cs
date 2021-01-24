     public class CustomTextField: UITextField
        {
            // A delegate type for hooking up change notifications.
            public delegate void DeleteBackwardKeyEventHandler(object sender, EventArgs e);
    
            // An event that clients can use to be notified whenever the
            // elements of the list change.
            public event DeleteBackwardKeyEventHandler OnDeleteBackwardKey;
    
    
            public void OnDeleteBackwardKeyPressed()
            {
                if (OnDeleteBackwardKey != null)
                {
                    OnDeleteBackwardKey(null, null);
                }
            }
    
            public override void DeleteBackward()
            {
                base.DeleteBackward();
                OnDeleteBackwardKeyPressed();
            }
    }
