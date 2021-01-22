    void repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
    {
        if (((DateTime)e.Item.DataItem).Date < DateTime.Now.Date)
        {
            Button participate = (Button)e.FindControl("ParticipateBtn");
            participate.Enabled = false;              
        }      
    }
`
