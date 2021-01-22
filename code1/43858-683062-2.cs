    BulletedList lstReference = (BulletedList) this.Master.FindControl("lstErrors");
    lstReference.Items.Add("Error occured contacting database.");
    lstReference.Items.Add("Error occured processing payment.");
    
    Panel panReference = (Panel) this.Master.FindControl("pnlErrors");
    panReference.Visible = true;
