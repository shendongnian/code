    var alertNode = xmlDoc.SelectSingleNode("/root/Alert");
    if (string.IsNullOrWhiteSpace(alertNode?.InnerText))
    {
        alertBox.Visible = false;
    }
    else
    {
        alertBox.Visible = true;
    }
