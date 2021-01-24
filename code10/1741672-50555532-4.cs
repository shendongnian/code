    public partial class MyAppMainForm : Form
    {
        public MyAppMainForm()
        {
            InitializeComponent();
            Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, 
                                                    AutomationElement.RootElement, 
                                                    TreeScope.Subtree, (UIElm, evt) =>
            {
                AutomationElement element = UIElm as AutomationElement;
                string AppText = element.Current.Name;
                if (element.Current.ProcessId != Process.GetCurrentProcess().Id && AppText == this.Text)
                {
                    this.Invoke((MethodInvoker)delegate {
                        this.Visible = true;
                        this.WindowState = FormWindowState.Normal;
                        this.Show();
                    });
                }
            });
        }    
    }
