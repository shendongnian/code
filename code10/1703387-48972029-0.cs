    public class CustomControl : SomeBaseControl
    {
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (your_condition_passes)
            {
                // Do your logic
                return; // Prevent the base control event from firing
            }
            base.OnMouseDown(mevent); // Allow the base control event to fire
        }
    }
