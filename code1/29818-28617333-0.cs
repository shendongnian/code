    public MyFormConstructor()
    {
        InitializeComponent();
        AddScrollListener(MyGrid, MyScrollEventHandler);
    }
    private void AddScrollListener(DataGridView dgv, ScrollEventHandler scrollEventHandler)
    {
       HScrollBar scrollBar = dgv.Controls.OfType<HScrollBar>().First();
       scrollBar.Scroll += scrollEventHandler;
    }
    private void MyScrollEventHandler(object sender, ScrollEventArgs e)
    {
       // Handler with e.Type set properly
    }
