           protected void gvGrammars_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                GridViewRow row = (GridViewRow)gvGrammars.Rows[e.RowIndex];
                string valor = row.Cells[0].Text;
                XDocument xdoc = XDocument.Load(Server.MapPath("voiceGrammar.grxml"));
                List<XElement> itemsToDelete = xdoc.Descendants("grammar").Elements("rule")
                   .Where(x => (string)x.Attribute("id") == "rule1").Elements("one-of").Elements("item").Where(y => (string)y.Value == valor).ToList();
                for (int i = itemsToDelete.Count - 1; i >= 0; i--)
                {
                    itemToDelete[i].Remove();
                }
             
                xdoc.Save(Server.MapPath("voiceGrammar.grxml"));
            }
