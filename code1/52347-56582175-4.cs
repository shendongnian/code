        public string JsonToXML(string json)
        {
            XDocument xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", ""));
            XElement root = new XElement("Root");
            root.Name = "Result";
            var dataTable = JsonConvert.DeserializeObject<DataTable>(json);
            root.Add(
                     from row in dataTable.AsEnumerable()
                     select new XElement("Record",
                                         from column in dataTable.Columns.Cast<DataColumn>()
                                         select new XElement(column.ColumnName, row[column])
                                        )
                   );
            xmlDoc.Add(root);
            return xmlDoc.ToString();
        }
