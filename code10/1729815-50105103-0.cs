    new Faq
    {
        Question = node.GetPropertyValue<string>("question"),
        Answer = node.GetPropertyValue<string>("answer"),
        Schemes = node.GetPropertyValue<string>("schemes"),
        SchemeTypes = node.GetPropertyValue<string>("schemetypes")
                          .Split(',')
                          .Select(s => new SchemeType { SchemeType = s })
    }
