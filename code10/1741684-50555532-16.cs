    public partial class MyAppMainForm : Form
    {
        public MyAppMainForm()
        {
            InitializeComponent();
            Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, 
                                                 AutomationElement.RootElement, 
                                                 TreeScope.Subtree, (uiElm, evt) =>
            {
                AutomationElement element = uiElm as AutomationElement;
                string windowText = element.Current.Name;
                if (element.Current.ProcessId != Process.GetCurrentProcess().Id && windowText == this.Text)
                {
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.Show();
                    }));
                }
            });
        }    
    }
