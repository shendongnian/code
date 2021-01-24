    IQueryable<MyEntity> query = ....;
    if (rbvalveStreet.Checked && !string.IsNullOrEmpty(valveStreet.Text))
    {
        var searchText=valveStreet.Text;
        query=query.Where(item=>item.valveStreet.Contains(searchText);
    }
    if (rbhealth.Checked)
    {
        //Do we really want the *indexes*?
        //SHouldn't this be the selected text/value?
        var healthIdx=health.SelectedIndex;
        query = query.Where(itme=>item.health = healthIdx);
    }
    if (rbleak.Checked)
    {
        var leakIdx=leak.SelectedIndex;
        query = query.Where(item=>item.leak = leakIdx);
    }
    if (chbDateRange.Checked)
    {
        //No need to cast if this is a DateTimePicker control
        DateTime fromDate = dtsFrom.Value; 
        DateTime toDate = dtsTo.Value; 
        query = query.Where(item=> item.washdate >=fromDate
                                && item.washdate<= toDate)
    }
