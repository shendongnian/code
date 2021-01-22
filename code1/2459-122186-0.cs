    public partial class MainForm : Form
    {
        public enum FormViews
        {
            A, B
        }
        private MyViewA viewA; //user control with view a on it 
        private MyViewB viewB; //user control with view b on it
     
        private FormViews _formView;
        public FormViews FormView
        {
            get
            {
                return _formView;
            }
            set
            {
                _formView = value;
                OnFormViewChanged(_formView);
            }
        }
        protected virtual void OnFormViewChanged(FormViews view)
        {
            //contentPanel is just a System.Windows.Forms.Panel docked to fill the form
            switch (view)
            {
                case FormViews.A:
                    if (viewA != null) viewA = new MyViewA();
                    //extension method, you could use a static function.
                    this.contentPanel.DockControl(viewA); 
                    break;
                case FormViews.B:
                    if (viewB != null) viewB = new MyViewB();
                    this.contentPanel.DockControl(viewB);
                    break;
            }
        }
        public MainForm()
        {
          
            InitializeComponent();
            FormView = FormViews.A; //simply change views like this
        }
    }
    public static class PanelExtensions
    {
        public static void DockControl(this Panel thisControl, Control controlToDock)
        {
            thisControl.Controls.Clear();
            thisControl.Controls.Add(controlToDock);
            controlToDock.Dock = DockStyle.Fill;
        }
    }
