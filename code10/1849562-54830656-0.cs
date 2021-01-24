    protected void uxTicketHistoryButton_Click(object sender, EventArgs e)
    {
        DataTable ticketHist = _dtMgr.GetContactInfoByName(uxContactDropdownList.SelectedValue);
        string rName = ticketHist.Rows[0]["RequestorName"].ToString();
        string rPhone = ticketHist.Rows[0]["RequestorPhone"].ToString();
        ....
    
        uxTicketHistoryModal.Show();
    }
