    var td = OmanWorkflow.TrackingData.Where(o => 
                o.Created >= dateFrom.Value && o.Created <= dateTo.Value);
    // this likely should be o.Created < dateTo.Value
    //
    
    if (!string.IsNullOrEmpty(txtFilterJobNumber.Text))
    {
       td = td.Where(o.JobNumber.Contains(txtFilterJobNumber.Text));
    }
    if (!string.IsNullOrEmpty(txtFilterJobName.Text))
    {
       td = td.Where(o.JobName.Contains(txtFilterJobName.Text));
    }
    var t = new BindingList<Tracking>(td).ToList());
