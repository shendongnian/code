            string xml = theWebService.TheMethod();
            XDocument doc = XDocument.Parse(xml);
            var queryHeaders =
                from field in doc.Root.Element("header").Elements("field")
                select new
                {
                    Id = field.Attribute("id").Value,
                    Name = field.Value
                };
            var headers = queryHeaders.ToDictionary(f => f.Id, f => f.Name);
            DataTable table = new DataTable();
            foreach (var kvp in headers)
            {
                table.Columns.Add(kvp.Value);
            }
            Func<XElement, DataRow> rowGenerator =
                element =>
                {
                    var row = table.NewRow();
                    foreach (var field in element.Elements("field"))
                    {
                        string fieldId = field.Attribute("id").Value;
                        string columnName = headers[fieldId];
                        string value = field.Value;
                        row[columnName] = value;
                    }
                    return row;
                };
            var rows =
                from rowElement in doc.Root.Element("data").Elements("row")
                select rowGenerator(rowElement);
            foreach (var row in rows)
            {
                table.Rows.Add(row);
            }
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = table;
