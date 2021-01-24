    private PushButtonState DetermineState(bool up) {
        PushButtonState state = PushButtonState.Normal;
    
        if (!up) {
            state = PushButtonState.Pressed;
        }
        else if (Control.MouseIsOver) {
            state = PushButtonState.Hot;
        }
        else if (!Control.Enabled) {
            state = PushButtonState.Disabled;
        }
        else if (Control.Focused || Control.IsDefault) {
            state = PushButtonState.Default;
        }
 
        return state;
    }
