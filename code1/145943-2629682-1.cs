            XElement xElement = XElement.Load("file.xml");
            DataTable dTable = new DataTable();
            // keys must have unique name
            xElement.Elements().First().Elements().ToList()
                .ForEach(element=>dTable.Columns.Add(element.Name.ToString()));
            xElement.Elements().ToList().ForEach((item) =>
                {
                    // fileds must place in the same order
                    // but you can correct it if you want
                    var itemToAdd = new List<string>();
                    item.Elements().ToList().ForEach(field => itemToAdd.Add(field.Value));
                    dTable.Rows.Add(itemToAdd.ToArray()); 
                }
            );
            dataGridView1.DataSource = dTable;
        }
