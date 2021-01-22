    public class BaseForm : Form
    {
        public BaseForm() 
        {
            this.Load += new EventHandler(BaseForm_Load);
        }
    
        void BaseForm_Load(object sender, EventArgs e)
        {
            this.HandleFocusTracking(this.Controls);
        }
    
        private void HandleFocusTracking(ControlCollection controlCollection)
        {
            foreach (Control control in controlCollection)
            {
                control.GotFocus += new EventHandler(control_GotFocus);
                this.HandleFocusTracking(controlCollection);
            }
        }
    
        void control_GotFocus(object sender, EventArgs e)
        {
            _activeControl = sender as Control;
        }
    
        public virtual Control ActiveControl
        {
            get { return _activeControl; }
        }
        private Control _activeControl;
    
    }
