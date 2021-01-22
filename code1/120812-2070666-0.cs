    string attivitaID = ((ImageButton)sender).ID.Split('_')[2];
    if(Request.Form["TxtAttivitaDescrizione_" + attivitaID] != null)
    {
            string a = Request.Form["TxtAttivitaDescrizione_" + attivitaID];        
            attivitaTableAdapter.UpdateID(a, Int32.Parse(attivitaID));
            tableCell.Controls.Clear();
            tableCell.InnerHtml = a;
    
    }
