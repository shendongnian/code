    public partial class _Default : 
        ViewBasePage<EmployeePresenter, IEmployeeView>, IEmployeeView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _presenter.OnViewInitialized();
            }
    
            _presenter.OnViewLoaded();
            Page.DataBind();
        }
    
        #region Implementation of IEmployeeView
    
        ...
    
        #endregion
    }
