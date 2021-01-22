    public class ButtonChange
    {
       // Starting off with an empty handler avoids pesky null checks
       public event EventHandler StateChanged = delegate {};
       private int _buttonState;
       // Do you really want a setter method instead of a property?
       public void SetButtonState(int state)
       {
           if (_buttonState == state)
           {
               return;
           }
           _buttonState = state;
           StateChanged(this, EventArgs.Empty);
       }
    }
