    public MainForm()
    {
        InitializeComponent();
        _presenter = new MainScreenPresenter(this);
        FormClosing += UxMainScreenFormClosing;
    }
    public bool WillDiscardChanges()
    {
        return MessageBox.Show("Changes have been made without being saved. Would you like to continue?", "Exiting", MessageBoxButtons.YesNo) == DialogResult.Yes;
    }
    protected void UxMainScreenFormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = !CloseView();
    }
