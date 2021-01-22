    public class ChildForm : Form
    {
        public delegate SomeEventHandler(object sender, EventArgs e);
        public event SomeEventHandler SomeEvent;
        // Your code here
    }
    public class ParentForm : Form
    {
        ChildForm child = new ChildForm();
        child.SomeEvent += new EventHandler(this.HandleSomeEvent);
        public void HandleSomeEvent(object sender, EventArgs e)
        {
            this.someTextBox.Text = "Whatever Text You Want...";
        }
    }
