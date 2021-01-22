    public class MyPage : Page
    {
        public new bool IsPostBack
        {
            get { return Request.RequestType.Equals("POST", StringComparison.OrdinalIgnoreCase); }
        }
    }
