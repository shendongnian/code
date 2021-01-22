    public partial class SubAsstToolTipWindow : Form
    {
        public SubAsstToolTipWindow()
        {
            InitializeComponent();
            // Right after initializing create the event handler that 
            // traps the event in the class
            SubAsstToolTip.ToolTipShow += SubAsstToolTip_ToolTipShow;
        }
        private void SubAsstToolTip_ToolTipShow()
        {
            if (Vars.MyToolTipIsOn) // This boolean is a static one that I set in the other class.
            {
                // Call other private method on the form or do whatever
                ShowToolTip(Vars.MyToolTipText, Vars.MyToolTipX, Vars.MyToolTipY);     
            }
            else
            {
                HideToolTip();
            }
            
        }
