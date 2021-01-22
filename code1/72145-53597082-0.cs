    List<string> allParams = new List<string>();
    //here add fields you want to filter and their impact on rowview in string form
    if (tsPrzelewyTxtOpis.Text != ""){ allParams.Add("Opis like  '%" + tsPrzelewyTxtOpis.Text + "%'"); }
    if(tsPrzelewyTxtPlatnik.Text != ""){ allParams.Add("Płacący like  '%" + tsPrzelewyTxtPlatnik.Text + "%'"); }
    if(tsPrzelewyDropDownKonto.Text != "") { allParams.Add("Konto =  '" + tsPrzelewyDropDownKonto.Text + "'"); }
    if (tsPrzelewyDropDownWaluta.Text != "") { allParams.Add("Waluta =  '" + tsPrzelewyDropDownWaluta.Text + "'"); }
    if (tsPrzelewyDropDownStatus.Text != "") { allParams.Add("Status =  '" + tsPrzelewyDropDownStatus.Text + "'"); }
    
    string finalFilter = string.Join(" and ", allParams);
    if (finalFilter != "")
    { (dgvPrzelewy.DataSource as DataTable).DefaultView.RowFilter = "(" + finalFilter + ")"; }
    else
    { (dgvPrzelewy.DataSource as DataTable).DefaultView.RowFilter = ""; }
