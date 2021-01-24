            protected void gvGrammars_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                GridViewRow row = (GridViewRow)gvGrammars.Rows[e.RowIndex];
                string valor = row.Cells[0].Text;
                XDocument xdoc = XDocument.Load(Server.MapPath("voiceGrammar.grxml"));
                XNamespace ns = xdoc.Root.GetDefaultNamespace();
                List<XElement> itemToDelete = xdoc.Descendants(ns + "rule")
                   .Where(x => (string)x.Attribute("id") == "rule1").Select(y => y.Descendants(ns + "item").Where(z => z.FirstNode.ToString() == valor)).SelectMany(x => x).ToList();
                for (int i = itemToDelete.Count - 1; i >= 0; i--)
                {
                    itemToDelete[i].Remove();
                }
             
                xdoc.Save(Server.MapPath("voiceGrammar.grxml"));
            }
