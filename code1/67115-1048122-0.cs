    var partnersXml = dataContext.SomeTableInDb
         .Where(x => x.XmlType == "partner")
         .AsEnumerable() // This forces the rest of the query to be done in the CLR
         .Select(x => new {
              partnerId = XmlDocumentWrapper(x.XmlDocument)
                               .SelectSingleNode("//*[name()='partnerId']")
                               .InnerText
         });
