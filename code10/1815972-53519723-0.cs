    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //do not add or manipulate dynamic controls inside an ispostback check
        }
        //check if the session exists
        if (Session["list"] != null)
        {
            //add the correct number of textboxes from session
            for (int i = 1; i <= Convert.ToInt32(Session["list"]); i++)
            {
                addTextBox(i);
            }
        }
    }
    private void addTextBox(int index)
    {
        //create a new textbox
        TextBox tb = new TextBox();
        tb.ID = "DynamicTextBox" + index;
        tb.AutoPostBack = true;
        //add an event to the textbox
        tb.TextChanged += new EventHandler(quantity_TextChanged);
        //add the textbox to the page
        PlaceHolder1.Controls.Add(tb);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int index = 1;
        //get the current textbox count if it exists
        if (Session["list"] != null)
        {
            index = Convert.ToInt32(Session["list"]) + 1;
        }
        //add a new textbox
        addTextBox(index);
        //upate the session with the new value
        Session["list"] = index;
    }
    private void quantity_TextChanged(object sender, EventArgs e)
    {
        //display the textbox value in a label for testing
        Label1.Text = ((TextBox)sender).Text;
    }
