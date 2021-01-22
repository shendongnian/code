    public class MyPage : Page
    {
        public new bool IsPostBack
        {
            get 
            { 
              return 
                Request.Form.Keys.Count > 0 &&
                Request.RequestType.Equals("POST", StringComparison.OrdinalIgnoreCase); 
             }
        }
    }
