    if(myConfigSection.LabelsVisible.HasValue) {
        graph.Label.Visible = myConfigSection.LabelsVisible.Value;
    }
    else {
        graph.Label.Visible = true; // your default value
    }
