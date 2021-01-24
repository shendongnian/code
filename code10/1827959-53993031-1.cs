    public OtherPage()
    {
        this.InitializeComponent();
        Window.Current.CoreWindow.PointerMoved += CoreWindow_PointerMoved;
    }
    
    public void CoreWindow_PointerMoved(CoreWindow sender, PointerEventArgs args)
    {
        Point ptr = args.CurrentPoint.Position;
        double Xpage2 = ptr.X;
        MessagingCenter.Send<OtherPage, string>(this, "Tag", Xpage2.ToString());
    }
