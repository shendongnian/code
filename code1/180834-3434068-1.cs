        foreach (string s in new string[] { "ena", "dyo" })
        {
            Literal lTitle = new Literal();
            lTitle.Text = "<Br>" + s;
            LinkButton lbButton = new LinkButton();
            lbButton.Text = "<br>" + s;
            phAddOnMe.Controls.Add(lTitle);
            phAddOnMe.Controls.Add(lbButton);
        }
