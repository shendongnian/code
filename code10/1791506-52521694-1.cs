    foreach (var email in emails)
    {
        try {
            var list = new List<EmailMessage> { email };
            PropertySet properties = (BasePropertySet.FirstClassProperties);
            service.LoadPropertiesForItems(list, properties);
            <Process Email>
        }
    } 
