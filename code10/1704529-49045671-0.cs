    public partial class MainForm : Form, IHomeView
        {
            HomePresenter _Presenter;
            public MainForm()
            {
                InitializeComponent();
                Control.CheckForIllegalCrossThreadCalls = false;   //<-- add this
                _Presenter = new HomePresenter(this);
            }
    
            public string StatusListView
            {
                get
                {
                    return lstActivityLog.Text;
                }
                set
                {
                     lstActivityLog.Items.Add(value);
                }
            }
            
            private void button1_Click(object sender, EventArgs e)
            {
                _Presenter.LaunchLongOperation();
            }
        }
