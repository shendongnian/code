    int nUpdatePanelID = Convert.ToInt32(Session["CapRes_SkillsetUpdatePanel_Row"].ToString());
    UpdatePanel pnlSkillsetsMain = grdResources.Rows[nUpdatePanelID].FindControl("pnlSkillsetsMain") as UpdatePanel;
    GridView grdSkillsets = pnlSkillsetsMain.Controls[0].FindControl("CascadingSkillsets1").FindControl("grdSkillsets") as GridView;
    grdSkillsets.DataBind();
    ModalPopupExtender.Hide();
