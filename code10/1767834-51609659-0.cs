    public class PageVMDataSource
    {
    #region Attributes
    private readonly PageVM pageVM;
    private readonly ProductModel productModel;
    #endregion
    #region Public Methods
    
    public PageVMDataSource(PageVM pageVM, ProductModel productModel)
    {
        this.pageVM = pageVM;
        this.productModel= productModel;
    }
   
    public void Initialize()
    {
        this.productModel.PropertyChanged += this.OnProductModelPropertyChanged;
    }
    #endregion
    #region Event Handlers
    private void OnProductModelPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        switch (propertyChangedEventArgs.PropertyName)
        {
            case "ModelUpdateCount":
                this.pageVM.UpdateTotalOrderValue;
                break;
        }
    }
    #endregion
