    public class MainForm : Form
    {
        private bool currentTaskChanged;
        public MainForm()
        {
            InitializeComponent();
            InitializeChangeEvents();
        }
        public void LoadTask(ITask task)
        {
            if (currentTaskChanged)
            {
                // Confirm whether or not to save changes
            }
            // Code to change the current task view here ...
            currentTaskChanged = false;
        }
        private void InitializedChangedEvents()
        {
            IEventService service = IoC.Resolve<IEventService>();
            service.Changed += TaskChanged;
        }
        private void TaskChanged(object sender, EventArgs e)
        {
            currentTaskChanged = true;
        }
    }
