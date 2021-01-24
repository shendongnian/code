    protected void Page_Load(object sender, EventArgs e){
            Label lblDate = (Label) Master.FindControl("lblDate");
        
            lblDate.Text = DateTime.Now.ToString();
        }
