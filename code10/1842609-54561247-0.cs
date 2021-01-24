    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //do not create controls here
        }
        for (int count = 0; count < 5; count++)
        {
            TextBox answer = new TextBox();
            answer.ID = "answer " + count;
            PlaceHolder1.Controls.Add(answer);
        }
    }
