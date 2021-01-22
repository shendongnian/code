    public partial class LoginForm : Form, ILoginView
    {
        private ILoginPresenter _presenter;
        public LoginForm( IPresenterProvider presenterProvider )
        {
            InitializeComponent();
            _presenter = presenterProvider.Get<ILoginPresenter, ILoginView>( this );
        }
    }
