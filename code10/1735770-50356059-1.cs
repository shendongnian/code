    protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList dList = new DropDownList(); //instanciate the class
            dList.Items.Add("sdfghj"); // add list values
            dList.Items.Add("sdfghj");
            dList.Items.Add("sdfghj"); // add listvalues
            form1.Controls.Add(dList); //add your new dropdownlist to a form in your page
        }
