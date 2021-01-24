    public class MyForm : Form
    {
        private bool _stopEvent = false;
        private void OnComboSelectedIndexChanged(sender, e)
        {
            if (_stopEvent)
                return;
            // REAL event code here
        }
        private void DoSomething()
        {
             _stopEvent = true;
             cbo.SelectedIndex = 3;
             _stopEvent = false;
        }  
 
        // . . .  . . .  . . .
