    NameValueCollection eventProperties = new NameValueCollection();
    eventProperties.Add("keycode", "13");
    using(IE ie = new IE())
    {
     ie.TextField(Find.ById("myTextBox)).FireEvent("onkeypress", eventProperties);
    }
