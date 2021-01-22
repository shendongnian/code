    protected void ddlFilterResultBy_SelectedIndexChanged(object sender, EventArgs e)
                { 
                    string selVal = ddlFilterResultBy.SelectedValue.ToString().ToLower();
                            pnlDate.Visible = false;
                            pnlSubject.Visible = false;
                            pnlofficer.Visible = false;
                            pnlCIA.Visible = false;
                            pnlMedia.Visible = false;
                            pnlStatus.Visible = false;
                    switch (selVal)
                    {
                        case "date":
                            pnlDate.Visible = true;                    
                            break;
    
                        case "subject":
                            pnlSubject.Visible = true;
                            break;
    
                        case "officer":
                            pnlofficer.Visible = true;
                            break; 
                        case "status":
                            pnlStatus.Visible = true;
                            break;  
                    }
    
                }
