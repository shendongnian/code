    public partial class ChildForm : Form
    {
        private bool _isFormActive;
        public ChildForm()
        {
            ...
        }
    
        public void Fuction1()
        {
            if (_isFormActive)
            {
            }
            else
            {
            }
        }
    
    private void ChildForm1_Activated(object sender, System.EventArgs e)
    {
    	_isFormActive = true;
    }
    private void ChildForm1_Deactivated(object sender, System.EventArgs e)
    {
    	_isFormActive = false;
    }
    }
