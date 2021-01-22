    class BaseClass
    {
        public event CommandEventHandler ButtonCommand = delegate { };
    
        protected override void OnInit(EventArgs e)
        {
            foreach (Control possibleButton in Controls)
            {
                if (possibleButton is Button)
                {
                    Button button = (Button) possibleButton;
                    button.Command += AnyButtonCommandHandler;
                }
            }
            base.OnInit(e);
        }
    
        void AnyButtonCommandHandler(object sender, CommandEventArgs e)
        {
            // validation logic. if fails, return.
    
            ButtonCommand(sender, e);
        }
    }
    
    class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            base.ButtonCommand += base_ButtonCommand;
        }
    
        void base_ButtonCommand(object sender, CommandEventArgs e)
        {
            if (sender == button1) { ... }
            else if (sender == button2) { ... }
            // etc.
        }
    }
