    private Random
		random = new Random();
    private static int
		TEST = 0;
    	
	public void Page_Load (object sender, EventArgs ea)
	{		
		if( Page.IsPostBack ){
			if( IsTokenValid() ){
				DoWork();
			} else {
				// double click
				ltlResult.Text = "double click!";
			}
		} else {
			SetToken();
		}
	}
    
	private bool IsTokenValid ()
	{
		bool result = double.Parse(hidToken.Value) == ((double) Session["NextToken"]);
		SetToken();
		return result;
	}
    	
    private void SetToken ()
	{
		double next = random.Next();
		hidToken.Value       = next + "";
		Session["NextToken"] = next;
	}
    	
    	
    private void DoWork ()
	{
		TEST++;
		ltlResult.Text = "DoWork(): " + TEST + ".";
	}
