    var q = from c in recentOrdersXDoc.Descendants("prop")
            let handle = c.Element("handle")
            let clientTemplateID = (string)c.Element("TemplateID")
            let client = DataContext.Clients
                .Where(x=>x.ClientTemplateID == clientTemplateID)
                .Select(x=>new {x.ClientID, x.ClientName}).Single()
            select new ReturnResult()
            {
                ClientTemplateID = clientTemplateID,
                Handle = resultref != null ?
                       (string)resultref.Attribute("handle") : null,
                ClientID = client.ClientID,
                ClientName = client.ClientName
            };
