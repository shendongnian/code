    public ItemType_2View()
        {
             InitializeComponent();
             this.WhenActivated(dis =>
                    {
                      this.BindCommand(ViewModel, vm => vm.RunCommand, v => v.MenuItem_RunCommand).DisposeWith(dis);
    });
