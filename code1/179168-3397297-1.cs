    protected void ddlFilterResultBy_SelectedIndexChanged(object sender, EventArgs e) { 
      string selVal = ddlFilterResultBy.SelectedValue.ToString();
    
      pnlDate.Visible = String.Equals(selVal, "date", StringComparison.OrdinalIgnoreCase);
      pnlSubject.Visible = String.Equals(selVal, "subject", StringComparison.OrdinalIgnoreCase);
      pnlofficer.Visible = String.Equals(selVal, "officer", StringComparison.OrdinalIgnoreCase);
      pnlCIA.Visible = String.Equals(selVal, "cia", StringComparison.OrdinalIgnoreCase);
      pnlMedia.Visible = String.Equals(selVal, "media", StringComparison.OrdinalIgnoreCase);
      pnlStatus.Visible = String.Equals(selVal, "status", StringComparison.OrdinalIgnoreCase);
    }
