    private readonly DelegateCommand clickItemCommand;
     
    public MyViewModel()
    {
        this.clickItemCommand = new DelegateCommand( this.OnItemClick );
    }
    private void OnItemClick(Object parameter)
    {
        this.SelectedPopupType = PopupTypes.ItemDetail;
        this.IsShowPopup = true;
    }
    public DelegateCommand ClickItemCommand
    {
        get { retrn this.clickItemCommand; }
    }
