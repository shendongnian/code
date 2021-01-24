    public partial class View : System.Web.UI.UserControl, IView
    {
        public Presenter.Factory PresenterFactory { get; set; }
        public string Text
        {
            set
            {
                lbText.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var presenter = PresenterFactory(this);            
        }
    }
    public class Presenter
    {
        public delegate Presenter Factory(IView view);
        public Presenter(IView view)
        {
            view.Text = "Hello World";
        }
      
    }
