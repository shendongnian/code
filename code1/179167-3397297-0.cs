    protected void ddlFilterResultBy_SelectedIndexChanged(object sender, EventArgs e) { 
      string selVal = ddlFilterResultBy.SelectedValue.ToString().ToLower();
    
      pnlDate.Visible = (selVal == "date");
      pnlSubject.Visible = (selVal == "subject");
      pnlofficer.Visible = (selVal == "officer");
      pnlCIA.Visible = (selVal == "cia");
      pnlMedia.Visible = (selVal == "media");
      pnlStatus.Visible = (selVal == "status");
    }
