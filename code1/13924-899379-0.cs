            XDocument doc = XDocument.Load("sample.xml");
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "sample.xsd");
            bool errors = false;
            doc.Validate(schemas, (sender, e) =>
            {
                errors = true;
            });
            List<XElement> good = new List<XElement>();
            List<XElement> bad = new List<XElement>();
            var orders = doc.Descendants("Order");
            if (errors)
            {
                foreach (var order in orders)
                {
                    errors = false;
                    order.Validate(order.GetSchemaInfo().SchemaElement, schemas, (sender, e) =>
                    {
                        errors = true;
                    });
                    if (errors)
                        bad.Add(order);
                    else
                        good.Add(order);
                }
            }
            else
            {
                good = orders.ToList();
            }
