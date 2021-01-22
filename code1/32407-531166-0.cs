    public partial class _Default : AbstractPage, IEmployeeView
    {
        private EmployeePresenter presenter;
    
        private EmployeePresenter Presenter
        {
            set
            {
                presenter = value;
                presenter.View = this;
            }
        }
        protected override void Do_Load(object sender, EventArgs args)
        {
            //do "on load" stuff 
        }
    }
