    JObject ph1json = string.IsNullOrEmpty(crphoto1)
        ? new JObject
        {
            {"ContactID", crcontactID},
            {"Photo1", ""}
        }
        : new JObject
        {
            {"ContactID", crcontactID},
            {"Photo1", File.ReadAllBytes(crphoto1)}
        };
