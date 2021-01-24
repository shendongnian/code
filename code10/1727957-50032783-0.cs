     public partial class MainMenu : UserControl
        {
            //this class will be checking native windows messages, the one we're interested in is "MouseDown" with 0x0201 code 
            //(i won't be describing the whole stuff what is going inside: have that checked if you wish in documentation :)
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            public class TestMessageFilter : IMessageFilter
            {
                const int WM_MOUSEMOVE = 0x200;
                const int WM_LBUTTONDOWN = 0x0201;
    
                public event EventHandler MouseMoved;
                public event EventHandler MouseDown;
    
                public bool PreFilterMessage(ref Message m)
                {
                    // Blocks all the messages relating to the left mouse button.
                    if (m.Msg == WM_LBUTTONDOWN)
                    {
                        MouseDown?.Invoke(this, new EventArgs());
                    }
                    return false;
                }
            }
    
    
            public MainMenu()
            {
                InitializeComponent();
                //use our class that checks Windows Messages, subscribe it's event
                var tmf = new TestMessageFilter();
                tmf.MouseDown += UserControl1_MouseDown;
                //and add our class to Application's messages filter.
                Application.AddMessageFilter(tmf);
    
                //use "ordinary" events to detect mouse enter/mouse leave over control
                this.MouseLeave += UserControl1_MouseLeave;
                this.MouseEnter += UserControl1_MouseEnter;
            }
    
            private void UserControl1_MouseDown(object sender, EventArgs e)
            {
                //if mouse is not over control make it's visible false
                if (mouseLeft)
                {
                    this.Visible = false;
                }
            }
    
            //variable to save mouse state (if that is over the control, or left)
            private bool mouseLeft;
    
            private void UserControl1_MouseEnter(object sender, EventArgs e)
            {
                mouseLeft = false;
            }
    
    
            private void UserControl1_MouseLeave(object sender, EventArgs e)
            {
                mouseLeft = true;
            }
    
        }
