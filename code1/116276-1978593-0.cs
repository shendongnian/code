    public partial class GraphForm : Form, IListener
    {
        public GraphForm()
        {
            InitializeComponent();
        }
        private void GraphForm_Load(object sender, EventArgs e)
        {
            EventAggregator.GetTheEventAggregator().Subscribe<CloseAllFormsEventArgs>(this);
        }
        public void Handle<TEventArgs>(TEventArgs e)
        {
            if (e.GetType() == typeof(CloseAllFormsEventArgs))
            {
                this.Close();
            }
        }
        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            EventAggregator.GetTheEventAggregator().Publish(this, new CloseAllFormsEventArgs());
        }
        private void GraphForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventAggregator.GetTheEventAggregator().CancelSubscription<CloseAllFormsEventArgs>(this);
        }
    }
