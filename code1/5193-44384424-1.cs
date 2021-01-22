    public partial class MainForm : Form
    {
    public bool hideForm = true;
    ...
    public MainForm (bool hideForm)
        {
            this.hideForm = hideForm;
            InitializeComponent();
        }
    ...
    protected override void OnVisibleChanged(EventArgs e)
        {
            if (this.hideForm)
                this.Visible = false;
            base.OnVisibleChanged(e);
        }
    ...
    }
