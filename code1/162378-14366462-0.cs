    myForm : Form
    {
      
        public ChildForm()
        {       
           KeyPress += KeyPressHandler;
        }
    
        public KeyPressHandler(object sender, KeyPressEventArgs e)
        {
           if (_parent != null)
           {
               _parent.NotifyKeyPress(e);
           } 
        }
    }
