    public class Button : Rectangle
    {
        private List<Delegate> _delegatesToNotifyForClick = new List<Delegate>();
        public void PleaseNotifyMeWhenClicked(Delegate d)
        {
            this._delegatesToNotifyForClick.Add(d);
        }
        // ...
        protected void GuiEngineToldMeSomeoneClickedMouseButtonInsideOfMyRectangle()
        {
            foreach (Delegate d in this._delegatesToNotifyForClick)
            {
                d.Invoke(this, this._someArgument);
            }
        }
    }
    // Then use that button in your form
    public class MyForm : Form
    {
        public MyForm()
        {
            Button myButton = new Button();
            myButton.PleaseNotifyMeWhenClicked(new Delegate(this.ShowMessage));
        }
        private void ShowMessage()
        {
            MessageBox.Show("I know that the button was clicked! :))))");
        }
     }
           
