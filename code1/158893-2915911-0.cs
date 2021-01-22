    // Potentially use int.TryParse here instead
    int visibleLabels = int.Parse(ddlTool.SelectedValue);
    for (int i = 0; i < labels.Count; i++)
    {
        labels[i].Visible = (i < visibleLabels);
        textBoxes[i].Visible = (i < visibleLabels);
    }
