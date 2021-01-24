    string alertContent;
            
    // If dealing with a plain-text field...
    var txtAlertNode = xmlDoc.SelectSingleNode("/root/txtAlert");
    alertContent = txtAlertNode?.InnerText;
    if (string.IsNullOrWhiteSpace(alertContent))
    {
        Console.WriteLine("No txtAlert content.");
        // alertBox.Visible = false;
    }
    else
    {
        Console.WriteLine("ALERT: " + alertContent);
        // alertBox.Visible = true;
    }
    // If dealing with a rich-text field...
    var rtfAlertNode = xmlDoc.SelectSingleNode("/root/rtfAlert");
    if (string.IsNullOrWhiteSpace(rtfAlertNode?.InnerText))
    {
        Console.WriteLine("No rtfAlert content.");
        // alertBox.Visible = false;
    }
    else
    {
        alertContent = rtfAlertNode.InnerXml;
        Console.WriteLine("ALERT: " + alertContent);
        // alertBox.Visible = true;
    }
