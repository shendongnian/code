    public partial class NotificationForm : Form
    {
        public static SynchronizationContext SyncContext { get; set; }
        public string Message
        {
            get { return lblNotification.Text; }
            set { lblNotification.Text = value; }
        }
        public bool CloseOnClick { get; set; }
        public NotificationForm()
        {
            InitializeComponent();
        }
        public static NotificationForm AsyncShowDialog(string message, bool closeOnClick)
        {
            if (SyncContext == null)
                throw new ArgumentNullException("SyncContext",
                                                "NotificationForm requires a SyncContext in order to execute AsyncShowDialog");
            NotificationForm form = null;
            //Create the form synchronously on the SyncContext thread
            SyncContext.Send(s => form = CreateForm(message, closeOnClick), null);
            //Call ShowDialog on the SyncContext thread and return immediately to calling thread
            SyncContext.Post(s => form.ShowDialog(), null);
            return form;
        }
        public static void ShowDialog(string message)
        {
            //Perform a blocking ShowDialog call in the calling thread
            var form = CreateForm(message, true);
            form.ShowDialog();
        }
        private static NotificationForm CreateForm(string message, bool closeOnClick)
        {
            NotificationForm form = new NotificationForm();
            form.Message = message;
            form.CloseOnClick = closeOnClick;
            return form;
        }
        public void AsyncClose()
        {
            SyncContext.Post(s => Close(), null);
        }
        private void NotificationForm_Load(object sender, EventArgs e)
        {
        }
        private void lblNotification_Click(object sender, EventArgs e)
        {
            if (CloseOnClick)
                Close();
        }
    }
