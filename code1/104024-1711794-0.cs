    public partial class _Default : System.Web.UI.Page, IPostEditView {
    
        PostEditController controller;
        public _Default()
        {
             var service = ServiceLocator.Current.GetInstance<IBlogDataService>();
             this.controller = new PostEditController(this, service);
        }
    }
