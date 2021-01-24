    return new XElement(ns1 + "TemplateParameters",
        new XElement(ns1 + "TemplateOrderLines",
            templateOrderLines.Select((item, index) => 
                new XElement($"Item{index}",
                    new XElement(ns1 + "TemplatePartDesc", item.TemplatePartDesc),
                    new XElement(ns1 + "TemplatePartSKU", item.TemplatePartSKU),
                    new XElement(ns1 + "TemplateQuantity", item.TemplateQuantity)
                )
            )
        )
    );
