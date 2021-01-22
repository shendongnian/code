    ParentForm : Form
    {
        public NotifyKeyPress(KeyPressEventArgs e)
        {
             OnKeyPress(e);
        }
    }
    
    ChildForm : Form
    {
        ParentForm _parent;
        public ChildForm(ParentForm parent)
        {
           _parent = parent;
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
