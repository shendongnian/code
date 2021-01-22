    if(myConfigSection.LabelsVisible.HasValue) {
        graph.Label.Visible = myConfigSection.LabelsVisible.Value;
    }
    else {
        graph.Label.Visible = // what you want the value to be when null
    }
