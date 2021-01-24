    protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Cart"] != null)
            {
                _tokenSource = HttpContext.Current.Session["Cart"] as CancellationTokenSource;
            }
            else
            {
                HttpContext.Current.Session.Add("Cart", new CancellationTokenSource());
                _tokenSource = HttpContext.Current.Session["Cart"] as CancellationTokenSource;
            }
        }
