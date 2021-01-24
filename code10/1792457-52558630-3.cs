    //we create a variable to store our window's last state
    FormWindowState lastState;
    public Form2()
    {
        InitializeComponent();
        //then we create an event for form size changed
        //i did use lambda for creating event but you can use ordinary way.
        this.SizeChanged += (s, e) =>
        {
            //when window size changed we check if current state
            //is not the same with the previous
            if (WindowState != lastState)
            {
                //i did use switch to show all 
                //but you can use if to get only minimized status
                switch (WindowState)
                {
                    case FormWindowState.Normal:
                        MessageBox.Show("normal");
                        break;
                    case FormWindowState.Minimized:
                        MessageBox.Show("min");
                        break;
                    case FormWindowState.Maximized:
                        MessageBox.Show("max");
                        break;
                    default:
                        break;
                }
                //and at the and of the event we store last window state in our
                //variable so we get single message when state changed.
                lastState = WindowState;
            }
        };
    }
